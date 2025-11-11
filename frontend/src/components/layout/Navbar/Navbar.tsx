import { useTranslation } from '@/lib/stores/useTranslation';
import NavbarLink from './NavbarLink';

export default function Navbar() {
  const translation = useTranslation();

  const links = [
    { content: translation.products.processors, to: '/processors' },
    { content: translation.products.graphicsCards, to: '/graphics-cards' },
    { content: translation.products.motherboards, to: '/motherboards' },
    { content: translation.products.rams, to: '/rams' },
    { content: translation.products.ssds, to: '/ssds' },
    { content: translation.products.powerSupplies, to: '/power-supplies' },
    { content: translation.products.monitors.category, to: '/monitors' }
  ];

  return (
    <nav className='border-b font-montserrat bg-theme-white text-sm flex flex-col md:flex-row gap-6 justify-center items-center border-gray-300 text-black'>
      {links.map((link, idx) => (
        <NavbarLink key={idx} {...link} />
      ))}
    </nav>
  );
}
