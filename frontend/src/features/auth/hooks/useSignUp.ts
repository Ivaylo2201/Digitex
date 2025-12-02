import type { AxiosError } from 'axios';
import type { SignUpSchema } from '../schemas/signUpSchema';
import { useMutation } from '@tanstack/react-query';
import { httpClient } from '@/lib/api/httpClient';
import { toast } from 'sonner';

type UseSignUpResponse = { token: string; role: string };
type UseSignUpAxiosError = AxiosError<{ message: string }>;
type UseSignUpRequest = SignUpSchema;

export function useSignUp() {
  return useMutation<UseSignUpResponse, UseSignUpAxiosError, UseSignUpRequest>({
    mutationFn: async (data) => {
      const res = await httpClient.post<UseSignUpResponse>(
        '/auth/sign-up',
        data
      );
      return res.data;
    },
    onError: (e) => {
      toast.error(e.response?.data.message || 'Something went wrong.');
    },
  });
}
