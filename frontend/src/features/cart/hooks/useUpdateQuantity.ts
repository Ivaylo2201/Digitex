import { useTranslation } from '@/features/language/hooks/useTranslation';
import type { ApiError } from '@/lib/api/ApiError';
import { httpClient } from '@/lib/api/httpClient';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import { toast } from 'sonner';

export function useUpdateQuantity(itemId: number) {
  const { hooks } = useTranslation();
  const queryClient = useQueryClient();

  return useMutation<void, ApiError, { newQuantity: number }>({
    mutationFn: async ({ newQuantity }) => {
      await httpClient.patch(`/carts/${itemId}/update`, { newQuantity });
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['cart'] });
    },
    onError: () => toast.error(hooks.generic.somethingWentWrong),
  });
}
