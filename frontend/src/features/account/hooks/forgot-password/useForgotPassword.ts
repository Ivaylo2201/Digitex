import type { ApiError } from '@/lib/api/ApiError';
import { httpClient } from '@/lib/api/httpClient';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useMutation } from '@tanstack/react-query';
import { toast } from 'sonner';
import type { ForgotPasswordSchema } from './useForgotPasswordSchema';

export function useForgotPassword() {
  const { hooks } = useTranslation();

  return useMutation<void, ApiError, ForgotPasswordSchema>({
    mutationFn: async (data) => {
      await httpClient.post('/users/forgot-password', data);
    },
    onSuccess: () => {
      toast.success(hooks.useForgotPassword.visitYourEmailToResetYourPassword, {
        duration: 10000,
      });
    },
    onError: () => {
      toast.error(hooks.generic.somethingWentWrong);
    },
  });
}
