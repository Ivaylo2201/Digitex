import { useAuth } from '@/lib/stores/useAuth';
import { useTranslation } from '@/lib/stores/useTranslation';
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
      <span>{translation.signOut}</span>
    </button>
  );
}
