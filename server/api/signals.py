from django.contrib.auth.models import User
from django.db.models.functions import Cast
from django.db.models.signals import post_delete, post_save
from django.db.models import F, QuerySet, Sum, DecimalField
from django.dispatch import receiver
from rest_framework.authtoken.models import Token

from .models import Cart, CartItem


@receiver(post_save, sender=CartItem)
@receiver(post_delete, sender=CartItem)
def recalculate_total(sender: CartItem, instance: CartItem, **_: dict):
    OUTPUT_FIELD_MAX_DIGITS: int = 10
    OUTPUT_FIELD_DECIMAL_PLACES: int = 4

    cart_items: QuerySet = instance.cart.cartitems.all()

    total_price_for_each_cartitem = (
        cart_items.annotate(
            price=F('product__base_price') - (F('product__base_price') * F('product__discount_percentage') / 100)
        ).annotate(
            price=Cast(F('quantity') * F('price'), output_field=DecimalField(
                max_digits=OUTPUT_FIELD_MAX_DIGITS, decimal_places=OUTPUT_FIELD_DECIMAL_PLACES))
        )
    )

    total_cart_items_price: float = (
        total_price_for_each_cartitem.aggregate(total=Sum('price'))['total']
    )

    instance.cart.subtotal = total_cart_items_price or 0
    instance.cart.save()


@receiver(post_save, sender=User)
def create_cart(sender: User, instance: User, created: bool, **_: dict):
    if created:
        Cart.objects.create(user=instance)


@receiver(post_save, sender=User)
def create_token(sender: User, instance: User = None, created: bool = False, **_):
    if created:
        Token.objects.create(user=instance)
