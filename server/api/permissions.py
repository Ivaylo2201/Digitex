from rest_framework.permissions import BasePermission
from rest_framework.request import Request

from .models import CartItem


class IsOwner(BasePermission):
    def has_object_permission(self, request: Request, _, obj: CartItem) -> bool:
        if obj.cart.user != request.user:
            return False
        
        return True