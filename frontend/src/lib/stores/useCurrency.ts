import { create } from 'zustand';
import getCurrencies from '../helpers/getCurrencies';

type CurrencyStore = {
  currency: string;
  currencies: string[];
  changeCurrency: (currency: string) => void;
};

export const useCurrency = create<CurrencyStore>((set) => {
  const currencies = getCurrencies();

  return {
    currency: currencies[0],
    currencies,
    changeCurrency: (currency) => set(() => ({ currency }))
  };
});
