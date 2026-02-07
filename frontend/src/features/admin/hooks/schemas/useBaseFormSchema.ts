import { useTranslation } from '@/features/language/hooks/useTranslation';
import z from 'zod';

export function useBaseFormSchema() {
  const {
    validationSchemas: { baseForm },
  } = useTranslation();

  return z.object({
    brandId: z
      .number({ required_error: baseForm.brandId.requiredError })
      .nonnegative(baseForm.brandId.nonNegativeError),
    modelName: z
      .string({ required_error: baseForm.modelName.requiredError })
      .min(1, baseForm.modelName.minLengthError),
    price: z
      .number({ required_error: baseForm.price.requiredError })
      .nonnegative(baseForm.price.nonNegativeError),
    discountPercentage: z
      .number({ required_error: baseForm.discountPercentage.requiredError })
      .min(0, baseForm.discountPercentage.minError)
      .max(100, baseForm.discountPercentage.maxError),
    quantity: z
      .number({ required_error: baseForm.quantity.requiredError })
      .int(baseForm.quantity.integerError)
      .nonnegative(baseForm.quantity.nonNegativeError),
  });
}
