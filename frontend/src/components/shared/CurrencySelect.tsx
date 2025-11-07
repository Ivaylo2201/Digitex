import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue
} from '@/components/ui/select';
import { useState } from 'react';
import Currency from './Currency';

const currencies = ['eur', 'usd', 'gbp', 'bgn'];

export default function LanguageSelect() {
  const [selectedCurrency, setselectedCurrency] = useState<string>(currencies[0]);

  const handleCurrencyChange = (currency: string) => {
    setselectedCurrency(currency);
  };

  return (
    <Select value={selectedCurrency} onValueChange={handleCurrencyChange}>
      <SelectTrigger className='font-montserrat text-xs shadow-none ring-0 outline-none border-0 focus-visible:ring-0 data-[state=open]:ring-0 data-[state=open]:border-0 cursor-pointer'>
        <SelectValue>
          <Currency code={selectedCurrency} />
        </SelectValue>
      </SelectTrigger>
      <SelectContent>
        {currencies.map((currency) => (
          <SelectItem className='cursor-pointer' key={currency} value={currency}>
            <Currency code={currency} />
          </SelectItem>
        ))}
      </SelectContent>
    </Select>
  );
}
