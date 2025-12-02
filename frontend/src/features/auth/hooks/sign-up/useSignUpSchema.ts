import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import z from 'zod';

export function useSignUpSchema() {
  const {} = useTranslation();

  return z
    .object({
      email: z.string({ required_error: '' }).email(''),
      username: z.string().min(3).max(20),
      password: z
        .string()
        .min(8)
        .regex(/^(?=.*[A-Za-z])(?=.*\d).+$/),
      passwordConfirmation: z
        .string()
        .min(8)
        .regex(/^(?=.*[A-Za-z])(?=.*\d).+$/),
    })
    .refine((data) => data.password === data.passwordConfirmation, {
      message: 'Passwords do not match',
      path: ['passwordConfirmation'],
    });
}

export type SignUpSchema = z.infer<ReturnType<typeof useSignUpSchema>>;
