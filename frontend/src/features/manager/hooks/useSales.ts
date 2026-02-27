import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';

export function useSales() {
  return useQuery({
    queryKey: ['sales'],
    queryFn: async () => {
      const res = await httpClient.get<
        { month: string; sales: number; revenue: number }[]
      >('/manager/sales/2026');
      return res.data;
    },
    staleTime: staleTime,
  });
}
