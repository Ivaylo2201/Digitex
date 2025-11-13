import { getCurrencySymbol } from '../helpers';
import { useCurrency } from '../stores/useCurrency';
import type { Currency } from '../types/currency';

const ratings: Record<Currency, number> = {
  eur: 1,
  gbp: 0.85,
  usd: 1.1
};

export default function useCurrencyExchange() {
  return {
    exchangeCurrency: (amount: number) => {
      const { currency } = useCurrency();
      const currencySymbol = getCurrencySymbol(currency);
      const exchangedAmount = amount * ratings[currency];

      return `${currencySymbol}${exchangedAmount.toFixed(2)}`;
    }
  };
}
