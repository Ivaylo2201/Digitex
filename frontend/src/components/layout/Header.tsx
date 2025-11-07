import CurrencySelect from '../shared/CurrencySelect';
import LanguageSelect from '../shared/LanguageSelect';

export default function Header() {
  return (
    <header className='text-white font-montserrat'>
      <section className='flex flex-col md:flex-row py-3 md:py-1 gap-y-2 justify-center md:justify-around items-center text-xs font-medium bg-theme-gunmetal'>
        <ul className='flex gap-6'>
          <li>{import.meta.env.VITE_MERCHANT_PHONE_NUMBER}</li>
          <li>{import.meta.env.VITE_MERCHANT_EMAIL}</li>
          <li>{import.meta.env.VITE_MERCHANT_ADDRESS}</li>
        </ul>
        <ul className='flex'>
          <CurrencySelect />
          <LanguageSelect />
        </ul>
      </section>
    </header>
  );
}
