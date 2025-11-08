import LanguageSelect from '@/components/shared/LanguageSelect/LanguageSelect';
import CurrencySelect from '@/components/shared/CurrencySelect/CurrencySelect';
import { useTranslation } from '@/lib/stores/useTranslation';
import { Mail, MapPin, Phone } from 'lucide-react';
import React from 'react';

export default function InformationSection() {
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
      </ul>
    </React.Fragment>
  );
}
