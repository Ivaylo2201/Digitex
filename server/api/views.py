from typing import Optional
from django.db.models import Q, QuerySet
from django.shortcuts import get_object_or_404
from django.contrib.auth.models import User
from rest_framework import status
from rest_framework.authentication import TokenAuthentication, authenticate
from rest_framework.authtoken.models import Token
import rest_framework.generics as views
from rest_framework.permissions import IsAuthenticated
from rest_framework.request import Request
from rest_framework.response import Response

from .permissions import IsOwner
from .serializers import (
    AddCartItemToCartSerializer,
    CartSerializer,
    ProductSerializer,
    UserSerializer,
)
from .models import Cart, CartItem, Order, Product


class DiscountedProductsListAPIView(views.ListAPIView):
    queryset = Product.objects.filter(discount_percentage__gt=0).order_by(
        "-date_added"
    )[0:8]
    serializer_class = ProductSerializer


class ProductsByCategoryListAPIView(views.ListAPIView):
    serializer_class = ProductSerializer

    def get_queryset(self) -> QuerySet:
        category: str = self.kwargs["category"][0:-1]
        return Product.objects.filter(category__iexact=category)


class ProductsByLookupListAPIView(views.ListAPIView):
    serializer_class = ProductSerializer

    def get_queryset(self) -> QuerySet:
        lookup: str = self.request.query_params["lookup"]
        criteria: Q = Q(name__icontains=lookup) | Q(category__icontains=lookup)

        if lookup is not None:
            return Product.objects.filter(criteria)

        return Product.objects.all()


class CartRetrieveAPIView(views.RetrieveAPIView):
    serializer_class = CartSerializer
    permission_classes = [IsAuthenticated]
    authentication_classes = [TokenAuthentication]

    def get_object(self) -> Cart:
        return Cart.objects.get(user=self.request.user)


class AddCartItemToCartCreateAPIView(views.CreateAPIView):
    authentication_classes = [TokenAuthentication]
    permission_classes = [IsAuthenticated]

    def post(self, request: Request) -> Response:
        serializer = AddCartItemToCartSerializer(data=request.data)

        if not serializer.is_valid():
            return Response(
                {"details": serializer.errors}, status=status.HTTP_400_BAD_REQUEST
            )

        cart: Cart = request.user.cart
        product: Product = Product.objects.get(pk=request.data["product"])
        quantity: int = request.data["quantity"]

        CartItem.objects.create(cart=cart, product=product, quantity=quantity)

        return Response(
            {"details": "Successfully added to cart"}, status=status.HTTP_201_CREATED
        )


class RemoveCartItemFromCartDestroyAPIView(views.DestroyAPIView):
    authentication_classes = [TokenAuthentication]
    permission_classes = [IsAuthenticated, IsOwner]

    def delete(self, request: Request, pk: int) -> Response:
        cart_item: CartItem = get_object_or_404(CartItem, pk=pk)
        self.check_object_permissions(request, cart_item)
        cart_item.delete()

        return Response(
            {"details": "Successfully removed from cart"},
            status=status.HTTP_204_NO_CONTENT,
        )


class PlaceOrderCreateAPIView(views.CreateAPIView):
    authentication_classes = [TokenAuthentication]
    permission_classes = [IsAuthenticated]

    def post(self, request: Request, *args, **kwargs) -> Response:
        cart: Cart = request.user.cart

        if cart.cartitems_count == 0:
            return Response(
                {"detail": "Shopping cart is empty"}, status=status.HTTP_400_BAD_REQUEST
            )

        Order.objects.create(
            user=request.user,
            items_count=cart.cartitems_count,
            total_price=cart.subtotal,
        )

        cart.cartitems.all().delete()

        return Response(
            {"detail": "Successfully placed order"}, status=status.HTTP_201_CREATED
        )


class SignUpUserCreateAPIView(views.CreateAPIView):
    serializer_class = UserSerializer


class SignInUserAPIView(views.CreateAPIView):
    def post(self, request: Request, *args, **kwargs) -> Response:
        username: str = request.data["username"]
        password: str = request.data["password"]

        user: Optional[User] = authenticate(username=username, password=password)

        if user is None:
            return Response(
                {"detail": "Invalid credentials!"}, status=status.HTTP_400_BAD_REQUEST
            )

        token: Token = Token.objects.get_or_create(user=user)[0]

        return Response({"token": token.key}, status=status.HTTP_200_OK)


class SignOutUserAPIView(views.DestroyAPIView):
    authentication_classes = [TokenAuthentication]
    permission_classes = [IsAuthenticated]

    def delete(self, request: Request, *args, **kwargs) -> Response:
        user: User = request.user
        Token.objects.filter(user=user).delete()
        return Response(
            {"detail": "User successfully signed out"}, status=status.HTTP_200_OK
        )
