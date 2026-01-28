import { useMutation, useQueryClient } from '@tanstack/react-query';
import type { WriteReviewSchema } from './useWriteReviewSchema';
import { httpClient } from '@/lib/api/httpClient';
import type { ApiError } from '@/lib/api/ApiError';
import { toast } from 'sonner';
import { useTranslation } from '@/features/language/hooks/useTranslation';

type UseWriteReviewResponse = {};

async function writeReview(data: WriteReviewSchema) {
  const res = await httpClient.post<UseWriteReviewResponse>('/reviews', data);
  return res.data;
}

export function useWriteReview() {
  const { hooks } = useTranslation();
  const queryClient = useQueryClient();

  return useMutation<UseWriteReviewResponse, ApiError, WriteReviewSchema>({
    mutationFn: writeReview,
    onSuccess: (_, variables) => {
      toast.success(hooks.useWriteReview.reviewSubmittedSuccessfully);
      queryClient.invalidateQueries({ queryKey: ['reviews'] });
      queryClient.invalidateQueries({ queryKey: [variables.productId] });
    },
    onError: () => toast.error(hooks.generic.somethingWentWrong),
  });
}
