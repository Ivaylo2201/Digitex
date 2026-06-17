import { Link } from 'react-router';
import { ArrowRight } from 'lucide-react';
import { useTranslation } from '@/features/language/hooks/useTranslation';

export function CtaBand() {
  const { home } = useTranslation();
  const { cta } = home;

  return (
    <section className='bg-theme-eerie-black px-6 pb-24 pt-4'>
      <div className='relative mx-auto max-w-7xl overflow-hidden rounded-2xl border border-theme-crimson/30 bg-gradient-to-br from-theme-crimson/15 via-theme-gunmetal to-theme-eerie-black px-8 py-14 md:px-14'>
        <div
          aria-hidden
          className='pointer-events-none absolute -right-16 -top-16 h-72 w-72 rounded-full bg-theme-crimson/20 blur-[100px]'
        />
        <div className='relative flex flex-col items-start gap-6 md:flex-row md:items-center md:justify-between'>
          <div className='max-w-xl'>
            <h2 className='text-2xl font-extrabold tracking-tight text-theme-white sm:text-3xl'>
              {cta.title}
            </h2>
            <p className='mt-3 text-base text-gray-300'>{cta.text}</p>
          </div>
          <Link
            to='/products/categories/processors'
            className='group inline-flex shrink-0 items-center gap-2 rounded-md bg-theme-crimson px-7 py-3.5 font-semibold text-theme-white shadow-lg shadow-theme-crimson/25 transition-colors duration-200 hover:bg-theme-lightcrimson focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-theme-crimson'
          >
            {cta.button}
            <ArrowRight
              size={18}
              className='transition-transform duration-200 group-hover:translate-x-1 motion-reduce:transition-none'
            />
          </Link>
        </div>
      </div>
    </section>
  );
}
