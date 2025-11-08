import { useTranslation } from '@/lib/stores/useTranslation';
import { LogIn } from 'lucide-react';
import { Link } from 'react-router';

export default function SignInButton() {
  const translation = useTranslation();

  return (
    <Link
      to='/auth/sign-in'
      className='flex justify-center items-center gap-1.5 cursor-pointer'
    >
      <LogIn className='text-theme-crimson' size={15} />
      <span>{translation.signIn}</span>
    </Link>
  );
}
