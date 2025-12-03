import type { SignUpSchema } from './useSignUpSchema';
import type { ApiError } from '@/lib/api/ApiError';
import { useMutation } from '@tanstack/react-query';
import { httpClient } from '@/lib/api/httpClient';
import { toast } from 'sonner';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useNavigate } from 'react-router';

type UseSignUpResponse = { token: string; role: string };

async function signUp(data: SignUpSchema) {
  const res = await httpClient.post<UseSignUpResponse>('/auth/sign-up', data);
  return res.data;
}

export function useSignUp() {
  const { hooks } = useTranslation();
  const navigate = useNavigate();

  return useMutation<UseSignUpResponse, ApiError, SignUpSchema>({
    mutationFn: signUp,
    onSuccess: () => {
      toast.success(hooks.useSignUp.visitYourEmailToVerifyYourAccount, {
        duration: 10000,
      });
      navigate('/auth/sign-in');
    },
    onError: (e) => {
      toast.error(e.response?.data.message || hooks.generic.somethingWentWrong); // TODO: remove e.response thing with translation
    },
  });
}
