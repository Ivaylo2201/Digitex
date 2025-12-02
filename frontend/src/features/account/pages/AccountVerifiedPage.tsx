import { useEffect } from 'react';
import { Navigate, useSearchParams } from 'react-router';
import { httpClient } from '@/lib/api/httpClient';
import { toast } from 'sonner';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';

function getVerifyUrl(token: string) {
  return `/auth/verify?token=${encodeURIComponent(token)}`;
}

export function AccountVerifiedPage() {
  const {
    components: { accountVerifiedPage },
  } = useTranslation();
  const [searchParams] = useSearchParams();

  useEffect(() => {
    const verifyAccount = async (token: string | null) => {
      if (token) {
        try {
          await httpClient.get(getVerifyUrl(token));
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
