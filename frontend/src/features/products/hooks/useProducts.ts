import { useQuery } from '@tanstack/react-query';
import type { ProductShort } from '../models/base/ProductShort';
import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';

async function fetchProducts(
  category: string,
  queryParams: string | undefined
) {
  const res = await httpClient.get<ProductShort[]>(
    `/products/${category}${queryParams ? `?${queryParams}` : ''}`
  );
  return res.data;
}

export function useProducts(category: string | undefined) {
  return useQuery({
    queryKey: ['products', category],
    queryFn: () => fetchProducts(category ?? '', window.location.href.split('?')[1]),
    staleTime: staleTime,
    retry: false,
  });
}
