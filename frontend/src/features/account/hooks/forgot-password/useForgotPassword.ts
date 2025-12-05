import type { ApiError } from '@/lib/api/ApiError';
import { httpClient } from '@/lib/api/httpClient';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useMutation } from '@tanstack/react-query';
import { useNavigate } from 'react-router';
import { toast } from 'sonner';
import type { ForgotPasswordSchema } from './useForgotPasswordSchema';

export function useForgotPassword() {
  const { hooks } = useTranslation();
  const navigate = useNavigate();

  return useMutation<void, ApiError, ForgotPasswordSchema>({
    mutationFn: async (data) => {
      await httpClient.post('/auth/forgot-password', data);
    },
    onSuccess: () => {
      toast.success(hooks.useForgotPassword.visitYourEmailToResetYourPassword, {
        duration: 10000,
      });
      navigate('/auth/sign-in');
    },
    onError: (e) => {
      toast.error(e.response?.data.message || hooks.generic.somethingWentWrong); // TODO: remove e.response thing with translation
    },
  });
}
