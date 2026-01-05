import { useTranslation } from '@/features/language/hooks/useTranslation';
import { ShoppingCart } from 'lucide-react';
import { Link } from 'react-router-dom';
import { useCart } from '../hooks/useCart';

export function CartLink() {
  const { data: cart } = useCart();
  const {
    components: { cartLink },
  } = useTranslation();

  const itemsCount =
    cart?.items.map((item) => item.quantity).reduce((a, b) => a + b, 0) ?? 0;

  return (
    <Link
      className='relative flex flex-col gap-0.5 justify-center items-center cursor-pointer'
      to='/cart'
    >
      <div className='relative'>
        <ShoppingCart size={19} />
        <span
          className={`size-4.5 flex justify-center items-center absolute -top-3 -right-4 rounded-full bg-theme-crimson text-[11px] text-theme-white font-Montserrat
    ${itemsCount > 0 ? 'block' : 'hidden'}`}
        >
          {itemsCount}
        </span>
      </div>
      <span className='text-theme-white text-xs font-Montserrat'>
        {cartLink.cart}
      </span>
    </Link>
  );
}
