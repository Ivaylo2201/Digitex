import type { Currency } from '../types/currency';

export default function getCurrencySymbol(
  currencyCode: Currency | string
): string {
  const symbols: Record<string, string> = {
    usd: '$',
    gbp: '£',
    eur: '€'
  };

  return symbols[currencyCode.toLowerCase()] || currencyCode;
}
