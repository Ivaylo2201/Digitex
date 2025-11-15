import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { User } from 'lucide-react';
import { Link } from 'react-router-dom';

export default function AccountLink() {
  const translation = useTranslation();

  return (
    <Link
      className='flex flex-col gap-0.5 justify-center items-center cursor-pointer'
      to='/auth/account'
    >
      <User size={19} />
      <span className='text-theme-white text-xs font-Montserrat'>
        {translation.user.account}
      </span>
    </Link>
  );
}
