import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';

type Category =
  | 'motherboards'
  | 'monitors'
  | 'processors'
  | 'graphics-cards'
  | 'power-supplies'
  | 'rams'
  | 'ssds'
  | 'other';

async function fetchFilters<T>(category: Category) {
  const res = await httpClient.get<T>(`/filters/${category}`);
  return res.data;
}

export function useFilters<T>(category: Category | undefined) {
  return useQuery({
    queryKey: [category, 'filters'],
    queryFn: () => fetchFilters<T>(category ?? 'other'),
    staleTime: staleTime,
    retry: false,
  });
}
