import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import z from 'zod';
import {
  FIELD_MIN_LENGTH,
  PASSWORD_MIN_LENGTH,
  PASSWORD_REGEX,
} from '../../constants';

export function useSignInSchema() {
  const {
    validationSchemas: { auth },
  } = useTranslation();

  return z.object({
    email: z
      .string()
      .min(FIELD_MIN_LENGTH, auth.email.requiredError)
      .email(auth.email.invalidEmailError),
    password: z
      .string()
      .min(FIELD_MIN_LENGTH, auth.password.requiredError)
      .min(PASSWORD_MIN_LENGTH, auth.password.minLengthError)
      .regex(PASSWORD_REGEX, auth.password.regexError),
    rememberMe: z.boolean().default(false),
  });
}

export type SignInSchema = z.infer<ReturnType<typeof useSignInSchema>>;
