import { Button } from '@/components/ui/button';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { ShoppingCart, X } from 'lucide-react';
import { Fragment } from 'react';
import { useAddToCart } from '../hooks/useAddToCart';

type AddToCartButtonProps = {
  isInStock: boolean;
  quantity: number;
  productId: string
};

export function AddToCartButton({ isInStock, quantity, productId }: AddToCartButtonProps) {
  const {
    components: { addToCartButton },
  } = useTranslation();

  const { mutate, isPending } = useAddToCart();

  return (
    <Button
      disabled={!isInStock || isPending}
      onClick={() => mutate({ productId, quantity })}
      className='flex-1 bg-theme-crimson hover:bg-theme-gunmetal transition-colors duration-300 cursor-pointer'
    >
      {isInStock ? (
        <Fragment>
          <ShoppingCart />
          {addToCartButton.addToCart}
        </Fragment>
      ) : (
        <Fragment>
          <X />
          {addToCartButton.outOfStock}
        </Fragment>
      )}
    </Button>
  );
}
