import { httpClient } from '@/lib/api/httpClient';
import type { Suggestion } from '../types/Suggestion';
import { useQuery } from '@tanstack/react-query';
import { staleTime } from '@/lib/api/constants';

export function useSuggestions(productId: string) {
  return useQuery({
    queryKey: ['suggestions', productId],
    queryFn: async () => {
      const res = await httpClient.get<Suggestion[]>(
        `/products/${productId}/suggestions`,
      );
      return res.data;
    },
    staleTime: staleTime,
    retry: false,
  });
}
