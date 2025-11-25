import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { LogIn } from 'lucide-react';
import { Link } from 'react-router';

export function SignInLink() {
  const {
    components: { signInLink }
  } = useTranslation();

  return (
    <Link
      to='/auth/sign-in'
      className='flex justify-center items-center gap-1.5 cursor-pointer'
    >
      <LogIn className='text-theme-crimson' size={15} />
      <span>{signInLink.signIn}</span>
    </Link>
  );
}
