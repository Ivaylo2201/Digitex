import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';
import type { MostSoldProduct } from '../types/MostSoldProduct';

export function useMostSoldProduct() {
  return useQuery({
    queryKey: ['most-sold'],
    queryFn: async () => {
      const res = await httpClient.get<MostSoldProduct>(
        '/manager/products/most-sold'
      );
      return res.data;
    }
  });
}
