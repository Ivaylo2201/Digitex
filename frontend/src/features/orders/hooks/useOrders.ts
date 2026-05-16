import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';
import type { Order } from '../types/Order';

export function useOrders() {
  return useQuery({
    queryKey: ['orders'],
    queryFn: async () => {
      const res = await httpClient.get<{ orders: Order[] }>('/orders');
      return res.data;
    },
    retry: false
  });
}
