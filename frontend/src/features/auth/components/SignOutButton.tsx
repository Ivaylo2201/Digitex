import { useAuth } from '@/features/auth/stores/useAuth';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { LogOut } from 'lucide-react';

export default function SignOutButton() {
  const { signOut } = useAuth();
  const translation = useTranslation();

  return (
    <button
      onClick={signOut}
      className='flex justify-center items-center gap-1.5 cursor-pointer'
    >
      <LogOut className='text-theme-crimson' size={15} />
      <span>{translation.auth.signOut}</span>
    </button>
  );
}
