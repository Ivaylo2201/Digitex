import { create } from 'zustand';
import type { Currency } from '../models/Currency';

type CurrencyStore = {
  currency: Currency;
  currencies: Currency[];
  changeCurrency: (currencyIsoCode: string) => void;
  setCurrencies: (currencies: Currency[]) => void;
};

export const useCurrencyStore = create<CurrencyStore>((set) => {
  const currency = { currencyIsoCode: 'EUR', sign: '€' };

  return {
    currency: currency,
    currencies: [currency],
    setCurrencies: (currencies) =>
      set({
        currencies,
        currency: currencies[1],
      }),
    changeCurrency: (currencyIsoCode) =>
      set((state) => {
        const currency =
          state.currencies.find((c) => c.currencyIsoCode === currencyIsoCode) ??
          state.currency;
        return { currency };
      }),
  };
});
