from django.urls import path, include

from .views import AddCartItemToCartCreateAPIView, CartRetrieveAPIView, DiscountedProductsListAPIView, PlaceOrderCreateAPIView, ProductsByCategoryListAPIView, ProductsByLookupListAPIView, RemoveCartItemFromCartDestroyAPIView, SignInUserAPIView, SignOutUserAPIView, SignUpUserCreateAPIView


urlpatterns = [
    path('accounts/', include(
        [
            path('signup/', SignUpUserCreateAPIView.as_view()),
            path('signin/', SignInUserAPIView.as_view()),
            path('signout/', SignOutUserAPIView.as_view()),
        ]
    )),
    path('products/', include(
        [
            path('discounted/', DiscountedProductsListAPIView.as_view()),
            path('search/', ProductsByLookupListAPIView.as_view()),
            path('<str:category>/', ProductsByCategoryListAPIView.as_view()),
        ]
    )),
    path('cart/', include(
        [
            path('', CartRetrieveAPIView.as_view()),
            path('add/', AddCartItemToCartCreateAPIView.as_view()),
            path('remove/<int:pk>/', RemoveCartItemFromCartDestroyAPIView.as_view())
        ]
    )),
    path('order/place/', PlaceOrderCreateAPIView.as_view())
]