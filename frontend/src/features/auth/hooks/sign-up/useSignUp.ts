import type { SignUpSchema } from './useSignUpSchema';
import type { ApiError } from '@/lib/api/ApiError';
import { useMutation } from '@tanstack/react-query';
import { httpClient } from '@/lib/api/httpClient';
import { toast } from 'sonner';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useNavigate } from 'react-router';

export function useSignUp() {
  const { hooks } = useTranslation();
  const navigate = useNavigate();

  return useMutation<void, ApiError, SignUpSchema>({
    mutationFn: async (data) => {
      await httpClient.post('/auth/sign-up', data);
    },
    onSuccess: () => {
      toast.success(hooks.useSignUp.visitYourEmailToVerifyYourAccount, {
        duration: 10000,
      });
      navigate('/auth/sign-in');
    },
    onError: () => {
      toast.error(hooks.generic.somethingWentWrong);
    },
  });
}
