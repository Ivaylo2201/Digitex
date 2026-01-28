import { useMutation, useQueryClient } from '@tanstack/react-query';
import type { CreateReviewSchema } from './useCreateReviewSchema';
import { httpClient } from '@/lib/api/httpClient';
import type { ApiError } from '@/lib/api/ApiError';
import { toast } from 'sonner';
import { useTranslation } from '@/features/language/hooks/useTranslation';

async function createReview(data: CreateReviewSchema) {
  const res = await httpClient.post<{}>('/reviews', data);
  return res.data;
}

export function useCreateReview() {
  const { hooks } = useTranslation();
  const queryClient = useQueryClient();

  return useMutation<{}, ApiError, CreateReviewSchema>({
    mutationFn: createReview,
    onSuccess: (_, variables) => {
      toast.success(hooks.useCreateReview.reviewSubmittedSuccessfully);
      queryClient.invalidateQueries({ queryKey: ['reviews'] });
      queryClient.invalidateQueries({ queryKey: ['products'] });
      queryClient.invalidateQueries({ queryKey: [variables.productId] });
    },
    onError: () => toast.error(hooks.generic.somethingWentWrong),
  });
}
