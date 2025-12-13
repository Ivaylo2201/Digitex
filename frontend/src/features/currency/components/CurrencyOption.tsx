import type { Currency } from '../models/Currency';

export function CurrencyOption({ currencyIsoCode, sign }: Currency) {
  return (
    <div className='flex items-center gap-2 font-montserrat text-xs'>
      <span className='text-theme-crimson font-semibold'>{sign}</span>
      <span>{currencyIsoCode}</span>
    </div>
  );
}
