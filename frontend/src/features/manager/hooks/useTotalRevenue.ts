import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';

export function useTotalRevenue() {
  return useQuery({
    queryKey: ['totalRevenue'],
    queryFn: async () => {
      const response = await httpClient.get<{ totalRevenue: number }>(
        '/manager/total-revenue',
      );
      return response.data;
    },
    staleTime: staleTime,
  });
}
