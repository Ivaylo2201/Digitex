import { useEffect } from 'react';
import { Link, useSearchParams } from 'react-router';
import { Check } from 'lucide-react';
import { Page } from '@/components/layout/Page';
import { httpClient } from '@/lib/api/httpClient';

export function AccountVerifiedPage() {
  const [searchParams] = useSearchParams();

  useEffect(() => {
    const token = searchParams.get('token');

    if (token) {
      httpClient.get(`/auth/verify?token=${encodeURIComponent(token)}`);
    }
  }, []);

  return (
    <Page>
      <div className='flex flex-col justify-center items-center bg-[#a7eb96] rounded-xl border-4 border-green-600 font-montserrat'>
        <Check size={120} className='text-green-600' />
        <p className='text-theme-gunmetal font-bold'>
          Account verification complete!
        </p>
        <Link to='/auth/sign-in'>Sign in</Link>
      </div>
    </Page>
  );
}
