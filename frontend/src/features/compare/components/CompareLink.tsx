import { ArrowRightLeft } from 'lucide-react';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { Link } from 'react-router';
import { useCompare } from '../stores/useCompare';

export function CompareLink() {
  const {
    components: { compareLink }
  } = useTranslation();
  const { products: comparedProducts } = useCompare();

  return (
    <Link
      className='relative flex flex-col gap-0.5 justify-center items-center cursor-pointer'
      to='/compare'
    >
      <div className='relative'>
        <ArrowRightLeft size={19} />
        {comparedProducts.length > 0 && (
          <span className='size-4.5 flex justify-center items-center absolute -top-3 -right-4 rounded-full bg-theme-crimson text-[11px] text-theme-white font-Montserrat'>
            {comparedProducts.length}
          </span>
        )}
      </div>
      <span className='text-theme-white text-xs font-Montserrat'>
        {compareLink.compare}
      </span>
    </Link>
  );
}
