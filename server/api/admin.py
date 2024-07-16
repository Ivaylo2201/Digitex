from django.contrib import admin

from .models import CartItem, Order, Product

@admin.register(Product)
class ProductAdmin(admin.ModelAdmin):
    list_display = [
        'pk',
        'name',
        'category',
        'base_price',
        'discount_percentage',
        'image',
        'price'
    ]

@admin.register(CartItem)
class CartItemAdmin(admin.ModelAdmin):
    list_display = [
        'pk',
        'cart',
        'product',
        'quantity'
    ]

@admin.register(Order)
class OrderAdmin(admin.ModelAdmin):
    list_display = [
        'pk',
        'user',
        'items_count',
        'total_price'
    ]