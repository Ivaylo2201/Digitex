import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { ShoppingCart } from 'lucide-react';
import { Link } from 'react-router-dom';

export function CartLink() {
  const { cart } = { cart: { items: [{}] } }; //useCart();
  const {
    components: { cartLink }
  } = useTranslation();

  return (
    <Link
      className='relative flex flex-col gap-0.5 justify-center items-center cursor-pointer'
      to='/cart'
    >
      <div className='relative'>
        <ShoppingCart size={19} />
        {cart.items.length > 0 && (
          <span className='size-4.5 flex justify-center items-center absolute -top-3 -right-4 rounded-full bg-theme-crimson text-[11px] text-theme-white font-Montserrat'>
            {cart.items.length}
          </span>
        )}
      </div>
      <span className='text-theme-white text-xs font-Montserrat'>
        {cartLink.cart}
      </span>
    </Link>
  );
}
