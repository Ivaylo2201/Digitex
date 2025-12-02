import { httpClient } from '@/lib/api/httpClient';
import { useMutation } from '@tanstack/react-query';
import { useNavigate } from 'react-router';
import { toast } from 'sonner';
import type { AxiosError } from 'axios';
import type { SignInSchema } from './useSignInSchema';
import { useAuth } from '../../stores/useAuth';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';

type UseSignInResponse = { token: string; role: string };
type UseSignInAxiosError = AxiosError<{ message: string }>; // refactor
type UseSignInRequest = SignInSchema;

async function signIn(data: UseSignInRequest) {
  const res = await httpClient.post<UseSignInResponse>('/auth/sign-in', data);
  return res.data;
}

export function useSignIn() {
  const { generic } = useTranslation();
  const navigate = useNavigate();
  const { signIn: storeSignIn } = useAuth();

  return useMutation<UseSignInResponse, UseSignInAxiosError, UseSignInRequest>({
    mutationFn: signIn,
    onSuccess: (res, { rememberMe }) => {
      storeSignIn(res.token, res.role, rememberMe);
      navigate('/');
    },
    onError: (e) => {
      toast.error(e.response?.data.message || generic.somethingWentWrong); // TODO: remove e.response thing with translation
    },
  });
}
