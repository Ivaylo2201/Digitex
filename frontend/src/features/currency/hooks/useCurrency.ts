import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';
import { type Currency } from '../models/Currency';
import { staleTime } from '@/lib/api/constants';

export function useCurrency() {
  return useQuery({
    queryKey: ['currency'],
    queryFn: async () => {
      const { data } = await httpClient.get<Currency[]>('/currencies');
      return data;
    },
    staleTime: staleTime,
    retry: false,
  });
}
