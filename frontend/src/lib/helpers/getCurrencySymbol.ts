// TODO: maek a $ | £ ... type
export default function getCurrencySymbol(currencyCode: string): string {
  const symbols: Record<string, string> = {
    usd: '$',
    bgn: 'лв.',
    gbp: '£',
    eur: '€'
  };

  return symbols[currencyCode.toLowerCase()] || currencyCode;
}
