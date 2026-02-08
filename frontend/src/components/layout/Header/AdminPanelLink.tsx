import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { Shield } from 'lucide-react';
import { Link } from 'react-router';

export function AdminPanelLink() {
  const {
    components: { adminPanelLink },
    routeNames,
  } = useTranslation();

  const links = [
    { content: routeNames['processors'], to: '/admin/processors' },
    { content: routeNames['graphics-cards'], to: '/admin/graphics-cards' },
    { content: routeNames['motherboards'], to: '/admin/motherboards' },
    { content: routeNames['rams'], to: '/admin/rams' },
    { content: routeNames['ssds'], to: '/admin/ssds' },
    { content: routeNames['power-supplies'], to: '/admin/power-supplies' },
    { content: routeNames['monitors'], to: '/admin/monitors' },
  ];

  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <button className='ml-4 flex justify-center items-center gap-1.5 cursor-pointer'>
          <Shield className='text-theme-crimson' size={16} />
          <span>{adminPanelLink.adminPanel}</span>
        </button>
      </DropdownMenuTrigger>
      <DropdownMenuContent>
        <DropdownMenuGroup className='font-montserrat font-medium text-theme-gunmetal'>
          {links.map((link) => (
            <DropdownMenuItem key={link.to}>
              <Link to={link.to} className='cursor-pointer'>
                <p>{link.content}</p>
              </Link>
            </DropdownMenuItem>
          ))}
        </DropdownMenuGroup>
      </DropdownMenuContent>
    </DropdownMenu>
  );
}
