import type { Currency } from './types/currency';

export const capitalize = (value: string) => {
  return value.charAt(0).toUpperCase() + value.slice(1);
};

export const getCurrencySymbol = (currencyCode: Currency | string): string => {
  const symbols: Record<string, string> = {
    usd: '$',
    gbp: '£',
    eur: '€'
  };

  return symbols[currencyCode.toLowerCase()] || currencyCode;
};
