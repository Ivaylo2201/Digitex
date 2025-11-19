import type { Currency } from '../models/Currency';

export const getCurrencySymbol = (currencyCode: Currency | string): string => {
  const symbols: Record<string, string> = {
    usd: '$',
    gbp: '£',
    eur: '€',
  };

  return symbols[currencyCode.toLowerCase()] || currencyCode;
};
