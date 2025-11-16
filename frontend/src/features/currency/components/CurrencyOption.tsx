import { getCurrencySymbol } from '../utils/getCurrencySymbol';

export default function CurrencyOption({ code }: { code: string }) {
  return (
    <div className='flex items-center gap-2 font-montserrat text-xs'>
      <span className='text-theme-crimson font-semibold'>
        {getCurrencySymbol(code)}
      </span>
      <span>{code.toUpperCase()}</span>
    </div>
  );
}
