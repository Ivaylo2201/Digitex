import type { Currency } from '../models/Currency';
import { useCurrency } from '../stores/useCurrency';
import { getCurrencySymbol } from '../utils/getCurrencySymbol';

const ratings: Record<Currency, number> = {
  eur: 1,
  gbp: 0.85,
  usd: 1.1
};

export default function useCurrencyExchange() {
  const { currency } = useCurrency();
  const currencySymbol = getCurrencySymbol(currency);

  return {
    exchangeCurrency: (amount: number) => {
      const exchangedAmount = amount * ratings[currency];
      return `${currencySymbol}${exchangedAmount.toFixed(2)}`;
    }
  };
}
