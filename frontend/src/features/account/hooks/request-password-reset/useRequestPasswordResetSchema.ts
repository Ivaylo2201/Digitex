import { useTranslation } from '@/features/language/hooks/useTranslation';
import { FIELD_MIN_LENGTH } from '@/lib/validation/constants';
import z from 'zod';

export function useRequestPasswordResetSchema() {
  const {
    validationSchemas: { auth },
  } = useTranslation();

  return z.object({
    email: z
      .string()
      .min(FIELD_MIN_LENGTH, auth.email.requiredError)
      .email(auth.email.invalidEmailError),
  });
}

export type RequestPasswordResetSchema = z.infer<
  ReturnType<typeof useRequestPasswordResetSchema>
>;
