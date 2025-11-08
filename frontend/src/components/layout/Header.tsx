import CurrencySelect from '@/components/shared/CurrencySelect/CurrencySelect';
import { Mail, MapPin, Phone, Search } from 'lucide-react';
import useTranslation from '@/lib/hooks/useTranslation';
import { Input } from '@/components/ui/input';
import { Button } from '@/components/ui/button';
import CartLink from '@/components/links/CartLink';
import AccountLink from '@/components/links/AccountLink';
import LogoLink from '@/components/links/LogoLink';
import LanguageSelect from '@/components/shared/CurrencySelect/CurrencySelect';

export default function Header() {
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
          <li className='w-50 flex justify-center md:justify-start items-center gap-1.5'>
            <MapPin size={16} className='text-theme-crimson' />
            {translation?.address}
          </li>
        </ul>
        <ul className='flex'>
          <CurrencySelect />
          <LanguageSelect />
        </ul>
      </section>

      <section className='bg-theme-eerie-black border-b-4 border-theme-crimson flex flex-col md:flex-row md:justify-around md:items-center p-4 gap-y-4'>
        <div className='md:w-1/3 uppercase flex justify-center items-center'>
          <LogoLink />
        </div>
        <div className='md:w-1/3 uppercase flex gap-2 justify-center items-center md:pb-0'>
          <Input
            type='email'
            placeholder={translation?.productSearch}
            className='w-2/3 text-sm font-medium placeholder-theme-eerie-black! selection:bg-theme-crimson bg-theme-white text-theme-eerie-black ring-0 outline-none border-0 focus-visible:ring-0 data-[state=open]:ring-0 data-[state=open]:border-0'
          />
          <Button
            variant='outline'
            size='icon'
            aria-label='Submit'
            className='cursor-pointer bg-theme-eerie-black hover:bg-theme-eerie-black text-xs text-theme-white hover:text-theme-white ring-0 outline-none border-0 focus-visible:ring-0 data-[state=open]:ring-0 data-[state=open]:border-0'
          >
            <Search />
          </Button>
        </div>
        <div className='md:w-1/3 flex justify-center items-center gap-6 pt-2.5 md:pt-0'>
          <AccountLink />
          <CartLink />
        </div>
      </section>
    </header>
  );
}
