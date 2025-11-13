import { useSuspenseQuery } from '@tanstack/react-query';
import { http } from '../http';

export default function useProduct<T>(category: string, id: string) {
  return useSuspenseQuery({
    queryKey: [category, id],
    queryFn: async () => {
      const res = await http.get<T>(`/products/${category}/${id}`);
      return res.data;
    },
    staleTime: 60 * 60 * 1000,
    retry: false
  });
}
