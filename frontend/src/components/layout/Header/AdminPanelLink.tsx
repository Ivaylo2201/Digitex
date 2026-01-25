import { useTranslation } from '@/features/language/hooks/useTranslation';
import { Shield } from 'lucide-react';
import { Link } from 'react-router';

export function AdminPanelLink() {
  const {
    components: { adminPanelLink },
  } = useTranslation();

  return (
    <Link
      to='/admin-panel'
      className='ml-4 flex justify-center items-center gap-1.5 cursor-pointer'
    >
      <Shield className='text-theme-crimson' size={16} />
      <span>{adminPanelLink.adminPanel}</span>
    </Link>
  );
}
