import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import {
  FIELD_MIN_LENGTH,
  PASSWORD_MIN_LENGTH,
  PASSWORD_REGEX,
} from '@/lib/validation/constants';
import z from 'zod';

export function useResetPasswordSchema() {
  const {
    validationSchemas: { auth },
  } = useTranslation();

  return z
    .object({
      newPassword: z
        .string()
        .min(FIELD_MIN_LENGTH, auth.password.requiredError)
        .min(PASSWORD_MIN_LENGTH, auth.password.minLengthError)
        .regex(PASSWORD_REGEX, auth.password.regexError),
      newPasswordConfirmation: z
        .string()
        .min(FIELD_MIN_LENGTH, auth.password.requiredError)
        .min(PASSWORD_MIN_LENGTH, auth.password.minLengthError)
        .regex(PASSWORD_REGEX, auth.password.regexError),
    })
    .refine((data) => data.newPassword === data.newPasswordConfirmation, {
      message: 'Passwords do not match',
      path: ['passwordConfirmation'],
    });
}

export type ResetPasswordSchema = z.infer<
  ReturnType<typeof useResetPasswordSchema>
>;
