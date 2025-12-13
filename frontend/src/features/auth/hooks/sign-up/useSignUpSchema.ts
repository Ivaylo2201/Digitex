import {
  FIELD_MIN_LENGTH,
  PASSWORD_MIN_LENGTH,
  PASSWORD_REGEX,
  USERNAME_MAX_LENGTH,
  USERNAME_MIN_LENGTH,
} from '../../../../lib/validation/constants';

import { useTranslation } from '@/features/language/hooks/useTranslation';
import z from 'zod';

export function useSignUpSchema() {
  const {
    validationSchemas: { auth },
  } = useTranslation();

  return z
    .object({
      email: z
        .string()
        .min(FIELD_MIN_LENGTH, auth.email.requiredError)
        .email(auth.email.invalidEmailError),
      username: z
        .string()
        .min(FIELD_MIN_LENGTH, auth.username.requiredError)
        .min(USERNAME_MIN_LENGTH, auth.username.minLengthError)
        .max(USERNAME_MAX_LENGTH, auth.username.maxLengthError),
      password: z
        .string()
        .min(FIELD_MIN_LENGTH, auth.password.requiredError)
        .min(PASSWORD_MIN_LENGTH, auth.password.minLengthError)
        .regex(PASSWORD_REGEX, auth.password.regexError),
      passwordConfirmation: z
        .string()
        .min(FIELD_MIN_LENGTH, auth.password.requiredError)
        .min(PASSWORD_MIN_LENGTH, auth.password.minLengthError)
        .regex(PASSWORD_REGEX, auth.password.regexError),
    })
    .refine(
      (data) =>
        !data.password.toLowerCase().includes(data.username.toLowerCase()),
      {
        message: auth.password.passwordContainsUsername,
        path: ['password'],
      }
    )
    .refine((data) => data.password === data.passwordConfirmation, {
      message: auth.password.passwordMismatchError,
      path: ['passwordConfirmation'],
    });
}

export type SignUpSchema = z.infer<ReturnType<typeof useSignUpSchema>>;
