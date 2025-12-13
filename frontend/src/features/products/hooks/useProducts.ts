import { useQuery } from '@tanstack/react-query';
import type { ProductShort } from '../models/base/ProductShort';
import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';
import { useLocation } from 'react-router';

async function fetchProducts(
  category: string,
  queryParams: string | undefined
) {
  const res = await httpClient.get<ProductShort[]>(
    `/products/${category}${queryParams}`
  );
  return res.data;
}

export function useProducts(category: string) {
  const location = useLocation();
  const { currency } = useCurrencyStore();

  return useQuery({
    queryKey: ['products', category, currency.currencyIsoCode],
    queryFn: () =>
      fetchProducts(
        category,
        `${location.search}&currencyIsoCode=${currency.currencyIsoCode}`
      ),
    staleTime: staleTime,
    retry: false,
  });
}
