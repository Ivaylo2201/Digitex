import { useTranslation } from '@/lib/stores/useTranslation';
import { ShoppingCart } from 'lucide-react';
import { Link } from 'react-router-dom';

export default function CartLink() {
  const { cart } = { cart: { items: [{}] } }; //useCart();
  const translation = useTranslation();

  return (
    <Link
      className='relative flex flex-col gap-0.5 justify-center items-center cursor-pointer'
      to='/cart'
    >
      <div className='relative'>
        <ShoppingCart size={19} />
        {cart.items.length > 0 && (
          <span className='size-4 flex justify-center items-center absolute -top-2 -right-4 rounded-full bg-theme-crimson text-xs text-theme-white font-Montserrat'>
            {cart.items.length}
          </span>
        )}
      </div>
      <span className='text-theme-white text-xs font-Montserrat'>
        {translation.user.cart}
      </span>
    </Link>
  );
}
