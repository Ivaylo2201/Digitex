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
      set((state) => ({
        currencies,
        currency:
          currencies.find(
            (c) => c.currencyIsoCode === state.currency.currencyIsoCode,
          ) ?? currencies[0],
      })),
    changeCurrency: (currencyIsoCode) =>
      set((state) => {
        const currency =
          state.currencies.find((c) => c.currencyIsoCode === currencyIsoCode) ??
          state.currency;
        return { currency };
      }),
  };
});
