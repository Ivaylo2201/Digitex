import { Button } from '@/components/ui/button';
import { Heart } from 'lucide-react';
import { useToggleFavorite } from '../hooks/useToggleFavorite';
import type { ProductLong } from '@/features/products/models/base/ProductLong';

type AddToFavoritesButtonProps = {
  product: ProductLong;
};

export function AddToFavoritesButton({ product }: AddToFavoritesButtonProps) {
  const { mutate } = useToggleFavorite();

  return (
    <Button
      onClick={() => mutate({ productId: product.id })}
      className='bg-theme-gunmetal hover:bg-theme-crimson transition-colors duration-300 cursor-pointer'
    >
      <Heart />
    </Button>
  );
}
