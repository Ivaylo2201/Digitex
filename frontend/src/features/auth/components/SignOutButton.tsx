import { useAuth } from '@/features/auth/stores/useAuth';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { LogOut } from 'lucide-react';

export function SignOutButton() {
  const { signOut } = useAuth();
  const {
    components: { signOutButton }
  } = useTranslation();

  return (
    <button
      onClick={signOut}
      className='flex justify-center items-center gap-1.5 cursor-pointer'
    >
      <LogOut className='text-theme-crimson' size={15} />
      <span>{signOutButton.signOut}</span>
    </button>
  );
}
