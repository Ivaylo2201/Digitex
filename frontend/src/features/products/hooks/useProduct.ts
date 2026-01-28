import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';
import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';

async function fetchProduct<T>(category: string, id: string, currency: string) {
  const res = await httpClient.get<T>(
    `/products/${category}/${id}?currency=${currency}`,
  );
  return res.data;
}

export function useProduct<T>(category: string, id: string) {
  const { currency } = useCurrencyStore();

  return useQuery({
    queryKey: [id, category, currency],
    queryFn: () => fetchProduct<T>(category, id, currency.currencyIsoCode),
    staleTime: staleTime,
    retry: false,
  });
}
