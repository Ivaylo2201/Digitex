import { type ProductShort } from '@/features/products/models/base/ProductShort';
import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';

export function useSearchedProducts(query: string) {
  return useQuery({
    queryKey: ['search', query],
    queryFn: async () => {
      const res = await httpClient.get<ProductShort[]>('/products/search', {
        params: { query }
      });

      return res.data;
    },
    staleTime: staleTime,
    retry: false
  });
}
