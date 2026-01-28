import { useTranslation } from '@/features/language/hooks/useTranslation';
import { z } from 'zod';

export function useCreateReviewSchema() {
  const {
    validationSchemas: { createReview },
  } = useTranslation();

  return z.object({
    productId: z.string().uuid(createReview.productId.invalidError),
    rating: z
      .number()
      .min(1, createReview.rating.requiredError)
      .max(5, createReview.rating.requiredError),
    comment: z.string().max(500, createReview.comment.maxLengthError),
  });
}

export type CreateReviewSchema = z.infer<
  ReturnType<typeof useCreateReviewSchema>
>;
