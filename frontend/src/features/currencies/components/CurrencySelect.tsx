import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue
} from '@/components/ui/select';
import { useCurrency } from '@/features/currencies/stores/useCurrency';
import CurrencyOption from './CurrencyOption';

export default function LanguageSelect() {
  const { currency, currencies, changeCurrency } = useCurrency();

  return (
    <Select value={currency} onValueChange={changeCurrency}>
      <SelectTrigger className='font-montserrat text-xs shadow-none ring-0 outline-none border-0 focus-visible:ring-0 data-[state=open]:ring-0 data-[state=open]:border-0 cursor-pointer'>
        <SelectValue>
          <CurrencyOption code={currency} />
        </SelectValue>
      </SelectTrigger>
      <SelectContent>
        {currencies.map((currency, idx) => (
          <SelectItem className='cursor-pointer' key={idx} value={currency}>
            <CurrencyOption code={currency} />
          </SelectItem>
        ))}
      </SelectContent>
    </Select>
  );
}
