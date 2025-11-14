import { create } from 'zustand';
import type { Currency } from '../models/Currency';

type CurrencyStore = {
  currency: Currency;
  currencies: Currency[];
  changeCurrency: (currency: Currency) => void;
};

export const useCurrency = create<CurrencyStore>((set) => {
  const currencies = (import.meta.env.VITE_APP_CURRENCIES as string).split(
    ','
  ) as Currency[];

  return {
    currency: currencies[0],
    currencies: currencies,
    changeCurrency: (currency) => set(() => ({ currency }))
  };
});
