import { useSuspenseQuery } from '@tanstack/react-query';
import type { ProductShort } from '../models/base/ProductShort';
import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';

async function fetchProducts(category: string) {
  const res = await httpClient.get<ProductShort[]>(`/products/${category}`);
  return res.data;
}

export function useProducts(category: string | undefined) {
  return useSuspenseQuery({
    queryKey: ['products', category],
    queryFn: () => fetchProducts(category ?? ''),
    staleTime: staleTime,
    retry: false,
  });
}
