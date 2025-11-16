import { Mail, MapPin, Phone } from 'lucide-react';
import AccountLink from '../../../features/account/components/AccountLink';
import CartLink from '../../../features/cart/components/CartLink';
import LogoLink from './LogoLink';
import Searchbox from './Searchbox';
import FavoritesLink from '../../../features/favorites/FavoritesLink';
import LanguageSelect from './LanguageSelect';
import SignOutButton from '../../../features/auth/components/SignOutButton';
import SignInLink from '../../../features/auth/components/SignInLink';
import { useAuth } from '@/features/auth/stores/useAuth';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import CompareLink from '../../../features/compare/components/CompareLink';
import CurrencySelect from '@/features/currency/components/CurrencySelect';

export default function Header() {
  const { isAuthenticated } = useAuth();
  const translation = useTranslation();

  return (
    <header className='text-white font-montserrat'>
      <section className='flex flex-col md:flex-row py-3 md:py-1 gap-y-2 justify-center md:justify-around items-center text-xs font-medium bg-theme-gunmetal'>
        <ul className='flex flex-col md:flex-row gap-4 md:gap-6'>
          <li className='flex justify-center items-center gap-1.5'>
            <Phone size={15} className='text-theme-crimson' />
            {import.meta.env.VITE_MERCHANT_PHONE_NUMBER}
          </li>
          <li className='flex justify-center items-center gap-1.5'>
            <Mail size={16} className='text-theme-crimson' />
            {import.meta.env.VITE_MERCHANT_EMAIL}
          </li>
          <li className='flex justify-center md:justify-start items-center gap-1.5'>
            <MapPin size={16} className='text-theme-crimson' />
            {translation.keywords.address}
          </li>
        </ul>
        <ul className='flex'>
          <CurrencySelect />
          <LanguageSelect />
          {isAuthenticated ? <SignOutButton /> : <SignInLink />}
        </ul>
      </section>

      <section className='bg-theme-eerie-black border-b-4 border-theme-crimson flex flex-col md:flex-row md:justify-around md:items-center py-5.5 gap-y-4'>
        <div className='md:w-1/3 uppercase flex justify-center items-center'>
          <LogoLink />
        </div>
        <div className='md:w-1/3 uppercase flex gap-2 justify-center items-center md:pb-0'>
          <Searchbox />
        </div>
        <div className='md:w-1/3 flex justify-center items-center gap-6 pt-2.5 md:pt-0'>
          <AccountLink />
          <CartLink />
          <FavoritesLink />
          <CompareLink />
        </div>
      </section>
    </header>
  );
}
