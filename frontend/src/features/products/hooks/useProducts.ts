import { useQuery } from '@tanstack/react-query';
import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';
import { useLocation } from 'react-router';

type FetchProductsResponse<T> = {
  items: T[];
  totalItems: number;
  totalPages: number;
};

async function fetchProducts<T>(
  category: string,
  queryParams: string | undefined
) {
  const res = await httpClient.get<FetchProductsResponse<T>>(
    `/products/${category}${queryParams}`
  );
  return res.data;
}

export function useProducts<T>(category: string, page: number, pageSize: number) {
  const location = useLocation();
  const { currency } = useCurrencyStore();

  return useQuery({
    queryKey: ['products', category, page, currency, location.search],
    queryFn: () => {
      const searchParams = location.search.split('?')[1];
      const queryParams = `?currency=${
        currency.currencyIsoCode
      }&page=${page}&pageSize=${pageSize}${
        searchParams ? `&${searchParams}` : ''
      }`;
      return fetchProducts<T>(category, queryParams);
    },
    staleTime: staleTime,
    retry: false,
  });
}