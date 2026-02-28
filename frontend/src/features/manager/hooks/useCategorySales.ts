import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';

export function useCategorySales() {
  return useQuery({
    queryKey: ['category-sales'],
    queryFn: async () => {
      const res = await httpClient.get<
        {
          category: string;
          percentage: number;
          count: number;
        }[]
      >('/manager/category-sales');
      return res.data;
    },
    staleTime: staleTime,
  });
}
