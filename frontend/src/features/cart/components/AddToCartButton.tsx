import { Button } from '@/components/ui/button';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { ShoppingCart, X } from 'lucide-react';
import { Fragment } from 'react';

type AddToCartButtonProps = {
  isInStock: boolean;
  quantity: number;
};

export function AddToCartButton({ isInStock, quantity }: AddToCartButtonProps) {
  const {
    components: { addToCartButton },
  } = useTranslation();

  return (
    <Button
      disabled={!isInStock}
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
