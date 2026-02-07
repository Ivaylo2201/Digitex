import { httpClient } from '@/lib/api/httpClient';
import { useMutation, useQueryClient } from '@tanstack/react-query';

export function useProductUpdate(category: string, id: string | undefined) {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (data: FormData) => {
      if (!id) return;

      const res = await httpClient.put(`/products/${category}/${id}`, data);
      console.log(res.data);
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['products', category] });
    },
    onError: (error) => {
      console.error('Error updating product:', error);
    },
  });
}
