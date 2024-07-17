from rest_framework import serializers

from .models import Cart, CartItem, Product
from .constraints import SERIALIZER_MAX_DIGITS, SERIALIZER_DECIMAL_PLACES


class BaseProductSerializer(serializers.ModelSerializer):
    price = serializers.DecimalField(
        max_digits=SERIALIZER_MAX_DIGITS,
        decimal_places=SERIALIZER_DECIMAL_PLACES
    )

    class Meta:
        model = Product
        fields = ['name', 'image', 'price']


class ProductSerializer(BaseProductSerializer):
    class Meta(BaseProductSerializer.Meta):
        model = BaseProductSerializer.Meta.model
        fields = BaseProductSerializer.Meta.fields + [
            'pk',
            'category',
            'base_price',
            'discount_percentage'
        ]


class CartItemProductSerializer(BaseProductSerializer):
    pass


class BaseCartItemSerializer(serializers.ModelSerializer):
    class Meta:
        model = CartItem
        fields = [
            'pk',
            'product',
            'quantity'
        ]


class CartItemSerializer(BaseCartItemSerializer):
    product = CartItemProductSerializer()


class AddCartItemToCartSerializer(BaseCartItemSerializer):
    pass


class CartSerializer(serializers.ModelSerializer):
    cartitems = CartItemSerializer(many=True)

    class Meta:
        model = Cart
        fields = [
            'cartitems',
            'subtotal',
            'cartitems_count'
        ]
