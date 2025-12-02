import { Button } from '@/components/ui/button';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { ShoppingCart, X } from 'lucide-react';
import { Fragment } from 'react';

type AddToCartButtonProps = {
  isInStock: boolean;
};

export function AddToCartButton({ isInStock }: AddToCartButtonProps) {
  const {
    components: { addToCartButton },
  } = useTranslation();

  return (
    <Button
      disabled={!isInStock}
      className='bg-theme-crimson hover:bg-theme-gunmetal transition-colors duration-300 cursor-pointer'
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
