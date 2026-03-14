import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';
import type { Suggestion } from '../types/Suggestion';
import { staleTime } from '@/lib/api/constants';

export function useSuggested(productId: string) {
  return useQuery({
    queryKey: ['suggested', productId],
    queryFn: async () => {
      const res = await httpClient.get<Suggestion[]>(
        `/products/${productId}/suggested`,
      );
      return res.data;
    },
    staleTime: staleTime,
    retry: false,
  });
}
