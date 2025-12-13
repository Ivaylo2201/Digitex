import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';

import { CurrencyOption } from './CurrencyOption';
import { useCurrencyStore } from '../stores/useCurrencyStore';
import { useCurrency } from '../hooks/useCurrency';
import { useEffect } from 'react';

export function CurrencySelect() {
  const { currency, currencies, changeCurrency, setCurrencies } =
    useCurrencyStore();
  const { data } = useCurrency();

  useEffect(() => {
    if (data) setCurrencies(data);
  }, [data]);

  return (
    <Select value={currency.currencyIsoCode} onValueChange={changeCurrency}>
      <SelectTrigger className='font-montserrat text-xs shadow-none ring-0 outline-none border-0 focus-visible:ring-0 data-[state=open]:ring-0 data-[state=open]:border-0 cursor-pointer'>
        <SelectValue>
          <CurrencyOption
            currencyIsoCode={currency.currencyIsoCode}
            sign={currency.sign}
          />
        </SelectValue>
      </SelectTrigger>
      <SelectContent>
        {currencies.map((currency, index) => (
          <SelectItem
            className='cursor-pointer'
            key={index}
            value={currency.currencyIsoCode}
          >
            <CurrencyOption {...currency} />
          </SelectItem>
        ))}
      </SelectContent>
    </Select>
  );
}
