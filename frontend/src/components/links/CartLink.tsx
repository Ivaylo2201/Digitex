import useTranslation from '@/lib/hooks/useTranslation';
import { ShoppingCart } from 'lucide-react';
import { Link } from 'react-router-dom';

export default function CartLink() {
  const translation = useTranslation();
  const { cart } = { cart: { items: [{}] } }; //useCart();

  return (
    <Link
      className='relative flex flex-col gap-0.5 justify-center items-center cursor-pointer'
      to='/'
    >
      <div className='relative'>
        <ShoppingCart size={19}></ShoppingCart>
        {cart.items.length > 0 && (
          <span className='size-4 flex justify-center items-center absolute -top-2 -right-2.5 rounded-full bg-theme-crimson text-xs text-theme-white font-Montserrat'>
            {cart.items.length}
          </span>
        )}
      </div>
      <span className='text-theme-white text-xs font-Montserrat'>
        {translation?.cart}
      </span>
    </Link>
  );
}
