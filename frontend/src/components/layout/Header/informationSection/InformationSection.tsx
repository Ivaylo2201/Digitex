import { useTranslation } from '@/lib/stores/useTranslation';
import { Mail, MapPin, Phone } from 'lucide-react';
import React from 'react';
import SignOutButton from '@/components/layout/header/informationSection/SignOutButton';
import { useAuth } from '@/lib/stores/useAuth';
import SignInButton from '@/components/layout/header/informationSection/SignInButton';
import CurrencySelect from '@/components/layout/header/informationSection/CurrencySelect';
import LanguageSelect from '@/components/layout/header/informationSection/LanguageSelect';

export default function InformationSection() {
  const { isAuthenticated } = useAuth();
  const translation = useTranslation();

  return (
    <React.Fragment>
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
          {translation.address}
        </li>
      </ul>
      <ul className='flex'>
        <CurrencySelect />
        <LanguageSelect />
        {isAuthenticated ? <SignOutButton /> : <SignInButton />}
      </ul>
    </React.Fragment>
  );
}
