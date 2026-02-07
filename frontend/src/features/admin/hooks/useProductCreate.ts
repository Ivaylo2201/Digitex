import { httpClient } from "@/lib/api/httpClient";
import { useMutation, useQueryClient } from "@tanstack/react-query";

export function useProductCreate(category: string) {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (data: FormData) => {
      const res = await httpClient.post(`/products/${category}`, data);
      console.log(res.data);
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['products', category] });
    },
    onError: (error) => {
      console.error('Error creating product:', error);
    },
  });
}
