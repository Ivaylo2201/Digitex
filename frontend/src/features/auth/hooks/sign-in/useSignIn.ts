import { httpClient } from '@/lib/api/httpClient';
import { useMutation } from '@tanstack/react-query';
import { useNavigate } from 'react-router';
import { toast } from 'sonner';
import type { SignInSchema } from './useSignInSchema';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import type { ApiError } from '@/lib/api/ApiError';
import { useAuthStore } from '../../stores/useAuth';

type UseSignInResponse = { token: string; role: string };

async function signIn(data: SignInSchema) {
  const res = await httpClient.post<UseSignInResponse>('/auth/sign-in', data);
  return res.data;
}

export function useSignIn() {
  const { hooks } = useTranslation();
  const navigate = useNavigate();
  const storeSignIn = useAuthStore((state) => state.signIn);

  return useMutation<UseSignInResponse, ApiError, SignInSchema>({
    mutationFn: signIn,
    onSuccess: (res, { rememberMe }) => {
      storeSignIn(res.token, res.role, rememberMe);
      navigate('/');
    },
    onError: () => toast.error(hooks.useSignIn.invalidCredentials)
  });
}
