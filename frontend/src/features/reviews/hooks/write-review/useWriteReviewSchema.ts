import { useTranslation } from '@/features/language/hooks/useTranslation';
import { z } from 'zod';

export function useWriteReviewSchema() {
  const {
    validationSchemas: { writeReview },
  } = useTranslation();

  return z.object({
    productId: z.string().uuid(writeReview.productId.invalidError),
    rating: z
      .number()
      .min(1, writeReview.rating.requiredError)
      .max(5, writeReview.rating.requiredError),
    comment: z.string().max(500, writeReview.comment.maxLengthError),
  });
}

export type WriteReviewSchema = z.infer<
  ReturnType<typeof useWriteReviewSchema>
>;
