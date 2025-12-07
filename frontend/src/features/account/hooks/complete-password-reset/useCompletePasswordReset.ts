import type { ApiError } from '@/lib/api/ApiError';
import { httpClient } from '@/lib/api/httpClient';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useMutation } from '@tanstack/react-query';
import type { AxiosResponse } from 'axios';
import { useNavigate } from 'react-router';
import { toast } from 'sonner';

type UseCompletePasswordResetRequest = { newPassword: string; token: string };

async function completePasswordReset(data: UseCompletePasswordResetRequest) {
  const res = await httpClient.patch('/accounts/complete-password-reset', data);
  return res.data;
}

export function useCompletePasswordReset() {
  const { hooks } = useTranslation();
  const navigate = useNavigate();

  return useMutation<AxiosResponse, ApiError, UseCompletePasswordResetRequest>({
    mutationFn: completePasswordReset,
    onSuccess: () => navigate('/auth/sign-in'),
    onError: () => {
      toast.error(hooks.generic.somethingWentWrong);
    },
  });
}
