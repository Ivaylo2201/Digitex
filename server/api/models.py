from decimal import Decimal
from django.db import models
from django.core.validators import MinValueValidator, MaxValueValidator
from django.contrib.auth.models import User

from .constraints import (
    CARTITEM_CART_RELATED_NAME,
    CARTITEM_QUANTITY_MAX_VALUE,
    CARTITEM_QUANTITY_MIN_VALUE,
    CART_SUBTOTAL_DECIMAL_PLACES,
    CART_SUBTOTAL_DEFAULT_VALUE,
    CART_SUBTOTAL_MAX_DIGITS,
    ORDER_PRICE_DECIMAL_PLACES,
    ORDER_PRICE_MAX_DIGITS,
    ORDER_USER_RELATED_NAME,
    PRODUCT_CATEGORY_MAX_LENGTH,
    PRODUCT_DISCOUNT_PERCENTAGE_MAX_VALUE,
    PRODUCT_DISCOUNT_PERCENTAGE_MIN_VALUE,
    PRODUCT_IMAGE_UPLOAD_DIRECTORY,
    PRODUCT_NAME_MAX_LENGTH,
    ProductCategory,
    PRODUCT_PRICE_MAX_DIGITS,
    PRODUCT_PRICE_DECIMAL_PLACES,
    PRODUCT_PRICE_MIN_VALUE,
    PRODUCT_DISCOUNT_PERCENTAGE_DEFAULT_VALUE,
)


class Product(models.Model):
    name = models.CharField(
        max_length=PRODUCT_NAME_MAX_LENGTH
    )

    category = models.CharField(
        max_length=PRODUCT_CATEGORY_MAX_LENGTH,
        choices=ProductCategory.choices
    )

    base_price = models.DecimalField(
        max_digits=PRODUCT_PRICE_MAX_DIGITS,
        decimal_places=PRODUCT_PRICE_DECIMAL_PLACES,
        validators=[MinValueValidator(PRODUCT_PRICE_MIN_VALUE)]
    )

    discount_percentage = models.PositiveSmallIntegerField(
        default=PRODUCT_DISCOUNT_PERCENTAGE_DEFAULT_VALUE,
        validators=[
            MinValueValidator(PRODUCT_DISCOUNT_PERCENTAGE_MIN_VALUE),
            MaxValueValidator(PRODUCT_DISCOUNT_PERCENTAGE_MAX_VALUE)
        ]
    )

    image = models.ImageField(
        upload_to=PRODUCT_IMAGE_UPLOAD_DIRECTORY
    )

    date_added = models.DateTimeField(
        auto_now_add=True,
        editable=False
    )

    @property
    def price(self) -> Decimal:
        return self.base_price - self.base_price * (Decimal(self.discount_percentage) / 100)
    
    def __str__(self) -> str:
        return self.name


class Cart(models.Model):
    user = models.OneToOneField(
        to=User,
        on_delete=models.CASCADE
    )

    subtotal = models.DecimalField(
        max_digits=CART_SUBTOTAL_MAX_DIGITS,
        decimal_places=CART_SUBTOTAL_DECIMAL_PLACES,
        default=CART_SUBTOTAL_DEFAULT_VALUE
    )

    @property
    def cartitems_count(self) -> int:
        total: int = 0    
        for item in self.cartitems.all():
            total += item.quantity
        return total
    
    def __str__(self) -> str:
        return f'{self.user.username}\'s cart'


class Order(models.Model):
    user = models.ForeignKey(
        to=User,
        on_delete=models.CASCADE,
        related_name=ORDER_USER_RELATED_NAME
    )

    items_count = models.PositiveSmallIntegerField(
        editable=False
    )

    total_price = models.DecimalField(
        max_digits=ORDER_PRICE_MAX_DIGITS,
        decimal_places=ORDER_PRICE_DECIMAL_PLACES
    )

    order_date = models.DateTimeField(
        auto_now_add=True,
        editable=False
    )


class CartItem(models.Model):
    cart = models.ForeignKey(
        to=Cart,
        on_delete=models.CASCADE,
        related_name=CARTITEM_CART_RELATED_NAME
    )

    product = models.ForeignKey(
        to=Product,
        on_delete=models.CASCADE,
    )

    quantity = models.PositiveSmallIntegerField(
        validators=[
            MinValueValidator(CARTITEM_QUANTITY_MIN_VALUE),
            MaxValueValidator(CARTITEM_QUANTITY_MAX_VALUE)
        ]
    )

    @property
    def price(self) -> Decimal:
        return self.product.price * self.quantity
