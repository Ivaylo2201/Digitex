import { useTranslation } from '@/lib/stores/useTranslation';
import { User } from 'lucide-react';
import { Link } from 'react-router-dom';

export default function AccountLink() {
  const translation = useTranslation();

  return (
    <Link
      className='flex flex-col gap-0.5 justify-center items-center cursor-pointer'
      to='/'
    >
      <User size={19} />
      <span className='text-theme-white text-xs font-Montserrat'>
        {translation.account}
      </span>
    </Link>
  );
}
