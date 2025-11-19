import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';

import { CurrencyOption } from './CurrencyOption';
import { useCurrency } from '../stores/useCurrency';

export function CurrencySelect() {
  const { currency, currencies, changeCurrency } = useCurrency();

  return (
    <Select value={currency} onValueChange={changeCurrency}>
      <SelectTrigger className='font-montserrat text-xs shadow-none ring-0 outline-none border-0 focus-visible:ring-0 data-[state=open]:ring-0 data-[state=open]:border-0 cursor-pointer'>
        <SelectValue>
          <CurrencyOption code={currency} />
        </SelectValue>
      </SelectTrigger>
      <SelectContent>
        {currencies.map((currency, index) => (
          <SelectItem className='cursor-pointer' key={index} value={currency}>
            <CurrencyOption code={currency} />
          </SelectItem>
        ))}
      </SelectContent>
    </Select>
  );
}
