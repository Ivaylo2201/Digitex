import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';
import type { Sale } from '../types/Sale';

export function useSales() {
  return useQuery({
    queryKey: ['sales'],
    queryFn: async () => {
      const res = await httpClient.get<Sale[]>(
        `/manager/sales/${new Date().getFullYear()}`,
      );
      return res.data;
    },
    staleTime: staleTime,
  });
}
