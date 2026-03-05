import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';
import type { CategorySale } from '../types/CategorySale';

export function useCategorySales() {
  return useQuery({
    queryKey: ['category-sales'],
    queryFn: async () => {
      const res = await httpClient.get<CategorySale[]>(
        '/manager/category-sales',
      );
      return res.data;
    },
    staleTime: staleTime,
  });
}
