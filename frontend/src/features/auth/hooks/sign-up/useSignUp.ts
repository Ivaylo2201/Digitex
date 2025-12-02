import type { AxiosError } from 'axios';
import { useMutation } from '@tanstack/react-query';
import { httpClient } from '@/lib/api/httpClient';
import { toast } from 'sonner';
import type { SignUpSchema } from './useSignUpSchema';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';

type UseSignUpResponse = { token: string; role: string };
type UseSignUpAxiosError = AxiosError<{ message: string }>; // refactor
type UseSignUpRequest = SignUpSchema;

async function signUp(data: UseSignUpRequest) {
  const res = await httpClient.post<UseSignUpResponse>('/auth/sign-up', data);
  return res.data;
}

export function useSignUp() {
  const { generic } = useTranslation();

  return useMutation<UseSignUpResponse, UseSignUpAxiosError, UseSignUpRequest>({
    mutationFn: signUp,
    onError: (e) => {
      toast.error(e.response?.data.message || generic.somethingWentWrong); // TODO: remove e.response thing with translation
    },
  });
}
