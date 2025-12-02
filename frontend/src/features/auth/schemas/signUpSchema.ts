import { z } from 'zod';

export const signUpSchema = z.object({
  email: z.string({ required_error: '' }).email(''),
  password: z
    .string()
    .min(8)
    .regex(/^(?=.*[A-Za-z])(?=.*\d).+$/),
  rememberMe: z.boolean(),
});

export type SignUpSchema = z.infer<typeof signUpSchema>;
