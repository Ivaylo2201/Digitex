import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { NavbarLink } from './NavbarLink';

export function Navbar() {
  const translation = useTranslation();

  const links = [
    { content: translation.routing['processors'], to: '/processors' },
    { content: translation.routing['graphics-cards'], to: '/graphics-cards' },
    { content: translation.routing['motherboards'], to: '/motherboards' },
    { content: translation.routing['rams'], to: '/rams' },
    { content: translation.routing['ssds'], to: '/ssds' },
    { content: translation.routing['power-supplies'], to: '/power-supplies' },
    { content: translation.routing['monitors'], to: '/monitors' }
  ];

  return (
    <nav className='border-b font-montserrat bg-theme-white text-sm flex flex-col md:flex-row gap-6 justify-center items-center border-gray-300 text-black'>
      {links.map((link, index) => (
        <NavbarLink key={index} {...link} />
      ))}
    </nav>
  );
}
