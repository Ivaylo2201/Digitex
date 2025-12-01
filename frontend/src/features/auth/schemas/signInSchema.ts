import { z } from 'zod';

export const signInSchema = z.object({
  email: z.string({ required_error: '' }).email(''),
  password: z
    .string()
    .min(8)
    .regex(/^(?=.*[A-Za-z])(?=.*\d).+$/),
  rememberMe: z.boolean(),
});

export type SignInSchema = z.infer<typeof signInSchema>;
