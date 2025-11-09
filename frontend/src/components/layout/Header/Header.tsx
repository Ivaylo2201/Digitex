import CategoriesSection from '@/components/layout/header/CategoriesSection';
import MainSection from '@/components/layout/header/MainSection';
import InformationSection from '@/components/layout/header/InformationSection';

export default function Header() {
  return (
    <header className='text-white font-montserrat'>
      <section className='flex flex-col md:flex-row py-3 md:py-1 gap-y-2 justify-center md:justify-around items-center text-xs font-medium bg-theme-gunmetal'>
        <InformationSection />
      </section>

      <section className='bg-theme-eerie-black border-b-4 border-theme-crimson flex flex-col md:flex-row md:justify-around md:items-center py-5.5 gap-y-4'>
        <MainSection />
      </section>

      <section className='border-b bg-theme-white text-sm flex flex-col md:flex-row gap-6 justify-center items-center border-gray-300 text-black'>
        <CategoriesSection />
      </section>
    </header>
  );
}
