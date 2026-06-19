import { httpClient } from '@/lib/api/httpClient';
import { useMutation, useQueryClient } from '@tanstack/react-query';

export function useProductDelete(category: string) {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (id: string) => {
      await httpClient.delete(`/products/${category}/${id}`);
    },
    onSuccess: () => {
      console.log("Invalidating queries for category:", category);
      queryClient.invalidateQueries({ queryKey: ['products', category] });
    },
  });
}
