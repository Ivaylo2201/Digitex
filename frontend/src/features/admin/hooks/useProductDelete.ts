import { httpClient } from '@/lib/api/httpClient';
import { useMutation, useQueryClient } from '@tanstack/react-query';

export function useProductDelete(category: string) {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (id: string) => {
      await httpClient.delete(`/products/${category}/${id}`);
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['products', category] });
    },
  });
}
