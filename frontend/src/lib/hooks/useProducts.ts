import { useSuspenseQuery } from '@tanstack/react-query';
import { http } from '@/lib/http';
import type { ProductShortDto } from '@/lib/models/productShortDto';

type UseProductsResponse = ProductShortDto[];

async function getProducts(category: string) {
  const res = await http.get<UseProductsResponse>(`/products/${category}`);
  return res.data;
}

export default function useProducts(category: string) {
  return useSuspenseQuery({
    queryKey: ['products', category],
    queryFn: () => getProducts(category),
    staleTime: 60 * 60 * 1000,
    retry: false
  });
}
