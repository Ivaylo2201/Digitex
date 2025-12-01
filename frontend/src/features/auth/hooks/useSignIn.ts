import { httpClient } from '@/lib/api/httpClient';
import { useMutation } from '@tanstack/react-query';
import { useNavigate } from 'react-router';
import { useAuth } from '../stores/useAuth';
import { toast } from 'sonner';
import type { AxiosError } from 'axios';
import type { SignInSchema } from '../schemas/signInSchema';

type UseSignInResponse = { token: string; role: string };
type UseSignInAxiosError = AxiosError<{ message: string }>;
type UseSignInRequest = SignInSchema;

export function useSignIn() {
  const navigate = useNavigate();
  const { signIn } = useAuth();

  return useMutation<UseSignInResponse, UseSignInAxiosError, UseSignInRequest>({
    mutationFn: async (data) => {
      const res = await httpClient.post<UseSignInResponse>(
        '/auth/sign-in',
        data
      );
      return res.data;
    },
    onSuccess: (res, { rememberMe }) => {
      signIn(res.token, res.role, rememberMe);
      navigate('/');
    },
    onError: (e) => {
      toast.error(e.response?.data.message || 'Something went wrong.');
    },
  });
}
