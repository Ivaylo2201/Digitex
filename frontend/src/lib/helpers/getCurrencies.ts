import type { Currency } from '../types/currency';

export default function getCurrencies() {
  try {
    const currencies = (import.meta.env.VITE_APP_CURRENCIES as string).split(
      ','
    );
    return currencies as Currency[];
  } catch (ex) {
    console.error(
      "Failed to configure currencies for application. Add 'VITE_APP_CURRENCIES' to .env"
    );
    return [];
  }
}
