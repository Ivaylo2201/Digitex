import { Button } from '@/components/ui/button';
import { Heart } from 'lucide-react';

export function AddToFavoritesButton() {
  return (
    <Button className='bg-theme-gunmetal hover:bg-theme-crimson transition-colors duration-300 cursor-pointer'>
      <Heart />
    </Button>
  );
}
