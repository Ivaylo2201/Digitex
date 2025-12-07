import type { ApiError } from '@/lib/api/ApiError';
import { httpClient } from '@/lib/api/httpClient';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useMutation } from '@tanstack/react-query';
import { toast } from 'sonner';
import type { RequestPasswordResetSchema } from './useRequestPasswordResetSchema';
import type { AxiosResponse } from 'axios';

async function requestPasswordReset(data: RequestPasswordResetSchema) {
  const res = await httpClient.post('/accounts/request-password-reset', data);
  return res.data;
}

export function useRequestPasswordReset() {
  const { hooks } = useTranslation();

  return useMutation<AxiosResponse, ApiError, RequestPasswordResetSchema>({
    mutationFn: requestPasswordReset,
    onSuccess: () => {
      const message = hooks.useForgotPassword.visitYourEmailToResetYourPassword;
      toast.success(message, { duration: 10000 });
    },
    onError: () => {
      toast.error(hooks.generic.somethingWentWrong);
    },
  });
}
