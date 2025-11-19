import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { Heart } from 'lucide-react';
import { Link } from 'react-router-dom';

export function FavoritesLink() {
  const { items } = { items: [{}] };
  const translation = useTranslation();

  return (
    <Link
      className='relative flex flex-col gap-0.5 justify-center items-center cursor-pointer'
      to='/favorites'
    >
      <div className='relative'>
        <Heart size={19} />
        {items.length > 0 && (
          <span className='size-4.5 flex justify-center items-center absolute -top-3 -right-4 rounded-full bg-theme-crimson text-[11px] text-theme-white font-Montserrat'>
            {items.length}
          </span>
        )}
      </div>
      <span className='text-theme-white text-xs font-Montserrat'>
        {translation.user.favorites}
      </span>
    </Link>
  );
}
