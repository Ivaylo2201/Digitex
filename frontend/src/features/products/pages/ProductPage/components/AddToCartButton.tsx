import { Button } from '@/components/ui/button';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { ShoppingCart } from 'lucide-react';

export function AddToCartButton() {
  const {
    components: { addToCartButton }
  } = useTranslation();

  return (
    <Button className='bg-theme-crimson hover:bg-theme-gunmetal transition-colors duration-300 cursor-pointer'>
      <ShoppingCart />
      {addToCartButton.addToCart}
    </Button>
  );
}
