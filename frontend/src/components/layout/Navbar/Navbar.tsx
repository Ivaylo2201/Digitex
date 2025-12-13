import { useTranslation } from '@/features/language/hooks/useTranslation';
import { NavbarLink } from './NavbarLink';

export function Navbar() {
  const { routeNames } = useTranslation();

  const links = [
    { content: routeNames['processors'], to: '/processors' },
    { content: routeNames['graphics-cards'], to: '/graphics-cards' },
    { content: routeNames['motherboards'], to: '/motherboards' },
    { content: routeNames['rams'], to: '/rams' },
    { content: routeNames['ssds'], to: '/ssds' },
    { content: routeNames['power-supplies'], to: '/power-supplies' },
    { content: routeNames['monitors'], to: '/monitors' },
  ];

  return (
    <nav className='border-b font-montserrat bg-theme-white text-sm flex flex-col md:flex-row gap-6 justify-center items-center border-gray-300 text-black'>
      {links.map((link, index) => (
        <NavbarLink key={index} {...link} />
      ))}
    </nav>
  );
}
