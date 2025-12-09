import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';

async function fetchFilters<T>(category: string) {
  const res = await httpClient.get<T>(`/products/${category}/filters`);
  return res.data;
}

export function useFilters<T>(category: string | undefined) {
  return useQuery({
    queryKey: [category, 'filters'],
    queryFn: () => fetchFilters<T>(category ?? ''),
    staleTime: staleTime,
    retry: false,
  });
}
