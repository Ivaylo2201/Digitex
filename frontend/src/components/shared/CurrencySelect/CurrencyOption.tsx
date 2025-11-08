import getCurrencySymbol from '@/lib/helpers/getCurrencySymbol';

type CurrencyOptionProps = {
  code: string;
};

export default function CurrencyOption({ code }: CurrencyOptionProps) {
  return (
    <div className='flex items-center gap-2 font-montserrat text-xs'>
      <span className='text-theme-crimson font-semibold'>
        {getCurrencySymbol(code)}
      </span>
      <span>{code.toUpperCase()}</span>
    </div>
  );
}
