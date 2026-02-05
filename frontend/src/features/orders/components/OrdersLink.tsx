import { useTranslation } from '@/features/language/hooks/useTranslation';
import { ShoppingBag } from 'lucide-react';
import { Link } from 'react-router';

export function OrdersLink() {
  const {
    components: { ordersLink },
  } = useTranslation();

  return (
    <Link
      className='flex flex-col gap-0.5 justify-center items-center cursor-pointer'
      to='/orders'
    >
      <ShoppingBag size={19} />
      <span className='text-theme-white text-xs font-Montserrat'>
        {ordersLink.orders}
      </span>
    </Link>
  );
}
