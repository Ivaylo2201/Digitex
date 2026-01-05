import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';
import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';
import { type Cart } from '../types/Cart';
import { staleTime } from '@/lib/api/constants';

async function getCart(currencyIsoCode: string) {
  const res = await httpClient.get<Cart>(`/carts?currency=${currencyIsoCode}`);
  return res.data;
}

export function useCart() {
  const currencyIsoCode = useCurrencyStore(
    (state) => state.currency.currencyIsoCode
  );

  return useQuery({
    queryKey: ['cart', currencyIsoCode],
    queryFn: () => getCart(currencyIsoCode),
    staleTime: staleTime,
    retry: false,
  });
}
