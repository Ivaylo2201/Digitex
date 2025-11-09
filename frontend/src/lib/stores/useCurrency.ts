import { create } from 'zustand';
import getCurrencies from '../helpers/getCurrencies';
import type { Currency } from '../types/currency';

type CurrencyStore = {
  currency: Currency;
  currencies: Currency[];
  changeCurrency: (currency: Currency) => void
};

export const useCurrency = create<CurrencyStore>((set) => {
  const currencies = getCurrencies();

  return {
    currency: currencies[0],
    currencies,
    changeCurrency: (currency) => set(() => ({ currency }))
  };
});
