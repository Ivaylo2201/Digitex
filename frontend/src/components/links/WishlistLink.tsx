import { useTranslation } from '@/lib/stores/useTranslation';
import { Heart } from 'lucide-react';
import { Link } from 'react-router-dom';

export default function WishlistLink() {
  const { items } = { items: [{}] }; //useWishlist();
  const translation = useTranslation();

  return (
    <Link
      className='relative flex flex-col gap-0.5 justify-center items-center cursor-pointer'
      to='/'
    >
      <div className='relative'>
        <Heart size={19} />
        {items.length > 0 && (
          <span className='size-4 flex justify-center items-center absolute -top-2 -right-4 rounded-full bg-theme-crimson text-xs text-theme-white font-Montserrat'>
            {items.length}
          </span>
        )}
      </div>
      <span className='text-theme-white text-xs font-Montserrat'>
        {translation.wishlist}
      </span>
    </Link>
  );
}
