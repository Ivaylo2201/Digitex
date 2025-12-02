import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import z from 'zod';

export function useSignInSchema() {
  const {} = useTranslation();

  return z.object({
    email: z.string({ required_error: '' }).email(''),
    password: z
      .string()
      .min(8)
      .regex(/^(?=.*[A-Za-z])(?=.*\d).+$/),
    rememberMe: z.boolean(),
  });
}

export type SignInSchema = z.infer<ReturnType<typeof useSignInSchema>>;
