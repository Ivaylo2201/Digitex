import { httpClient } from '@/lib/api/httpClient';
import { useSuspenseQuery } from '@tanstack/react-query';

async function fetchProduct<T>(category: string, id: string) {
  const res = await httpClient.get<T>(`/products/${category}/${id}`);
  return res.data;
}

export default function useProduct<T>(category: string, id: string) {
  return useSuspenseQuery({
    queryKey: [category, id],
    queryFn: () => fetchProduct<T>(category, id),
    staleTime: 60 * 60 * 1000,
    retry: false
  });
}
