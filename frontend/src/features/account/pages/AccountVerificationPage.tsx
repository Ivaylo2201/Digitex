import { useEffect } from 'react';
import { Navigate, useSearchParams } from 'react-router';
import { httpClient } from '@/lib/api/httpClient';
import { toast } from 'sonner';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useAuth } from '@/features/auth/stores/useAuth';

type AccountVerificationResponse = { token: string; role: string };

export function AccountVerificationPage() {
  const {
    components: { accountVerifiedPage },
  } = useTranslation();
  const [searchParams] = useSearchParams();
  const { signIn } = useAuth();

  useEffect(() => {
    const verifyAccount = async (token: string | null) => {
      if (token) {
        try {
          const { data: res } = await httpClient.patch<AccountVerificationResponse>('/users/verify', { token });
          signIn(res.token, res.role);
          toast.success(accountVerifiedPage.accountVerifiedSuccessfully);
        } catch {
          toast.error(accountVerifiedPage.accountVerificationFailed);
        }
      }
    };

    verifyAccount(searchParams.get('token'));
  }, []);

  return <Navigate to='/' replace={true} />;
}
