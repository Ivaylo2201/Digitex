import { ShieldUser } from 'lucide-react';
import { Link } from 'react-router';

type ManagerPageLinkProps = {};

export function ManagerPageLink({}: ManagerPageLinkProps) {
  //   const {
  //     components: { managerPageLink },
  //   } = useTranslation();

  return (
    <Link to='/manager' className='ml-4 flex justify-center items-center gap-1.5 cursor-pointer'>
      <ShieldUser className='text-theme-crimson' size={16} />
      <span>Manager page</span>
    </Link>
  );
}
