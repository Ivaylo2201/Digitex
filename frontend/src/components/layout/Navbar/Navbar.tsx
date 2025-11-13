import { useTranslation } from '@/lib/stores/useTranslation';
import NavbarLink from './NavbarLink';

export default function Navbar() {
  const translation = useTranslation();

  const links = [
    { content: translation.routing.processors, to: '/processors' },
    { content: translation.routing.graphicsCards, to: '/graphics-cards' },
    { content: translation.routing.motherboards, to: '/motherboards' },
    { content: translation.routing.rams, to: '/rams' },
    { content: translation.routing.ssds, to: '/ssds' },
    { content: translation.routing.powerSupplies, to: '/power-supplies' },
    { content: translation.routing.monitors, to: '/monitors' }
  ];

  return (
    <nav className='border-b font-montserrat bg-theme-white text-sm flex flex-col md:flex-row gap-6 justify-center items-center border-gray-300 text-black'>
      {links.map((link, idx) => (
        <NavbarLink key={idx} {...link} />
      ))}
    </nav>
  );
}
