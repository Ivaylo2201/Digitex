import type { ApiError } from '@/lib/api/ApiError';
import { httpClient } from '@/lib/api/httpClient';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useMutation } from '@tanstack/react-query';
import { useNavigate } from 'react-router';
import { toast } from 'sonner';

type UseResetPasswordRequest = { newPassword: string; token: string };

async function resetPassword(data: UseResetPasswordRequest) {
  await httpClient.post('/users/reset-password', data);
}

export function useResetPassword() {
  const { hooks } = useTranslation();
  const navigate = useNavigate();

  return useMutation<void, ApiError, UseResetPasswordRequest>({
    mutationFn: resetPassword,
    onSuccess: () => {
      navigate('/auth/sign-in');
    },
    onError: (e) => {
      toast.error(e.response?.data.message || hooks.generic.somethingWentWrong); // TODO: remove e.response thing with translation
    },
  });
}
