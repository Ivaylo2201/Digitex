import { Link } from 'react-router';
import {
  ArrowRight,
  Cpu,
  Gpu,
  MemoryStick,
  HardDrive,
  type LucideIcon,
} from 'lucide-react';
import { useTranslation } from '@/features/language/hooks/useTranslation';

const gridBackdrop: React.CSSProperties = {
  backgroundImage:
    'linear-gradient(to right, #ffffff 1px, transparent 1px), linear-gradient(to bottom, #ffffff 1px, transparent 1px)',
  backgroundSize: '48px 48px',
  maskImage: 'radial-gradient(ellipse at top right, black, transparent 70%)',
  WebkitMaskImage:
    'radial-gradient(ellipse at top right, black, transparent 70%)',
};

export function Hero() {
  const { home } = useTranslation();
  const { hero } = home;

  return (
    <section className='relative overflow-hidden bg-theme-eerie-black'>
      <div
        aria-hidden
        className='pointer-events-none absolute inset-0 opacity-[0.05]'
        style={gridBackdrop}
      />
      <div
        aria-hidden
        className='pointer-events-none absolute -top-32 right-0 h-[480px] w-[480px] rounded-full bg-theme-crimson/20 blur-[120px]'
      />

      <div className='relative mx-auto grid max-w-7xl grid-cols-1 items-center gap-16 px-6 py-20 md:py-28 lg:grid-cols-2'>
        <div className='duration-700 animate-in fade-in slide-in-from-bottom-3 motion-reduce:animate-none'>
          <p className='mb-5 inline-flex items-center gap-3 text-xs font-semibold uppercase tracking-[0.25em] text-theme-crimson'>
            <span className='h-px w-8 bg-theme-crimson' />
            {hero.eyebrow}
          </p>

          <h1 className='text-balance text-4xl font-extrabold leading-[0.98] tracking-tight text-theme-white sm:text-5xl lg:text-6xl'>
            {hero.title}{' '}
            <span className='text-theme-crimson underline decoration-theme-crimson/40 decoration-4 underline-offset-8'>
              {hero.titleHighlight}
            </span>
          </h1>

          <p className='mt-6 max-w-md text-base leading-relaxed text-gray-400'>
            {hero.subtitle}
          </p>

          <div className='mt-9 flex flex-wrap gap-4'>
            <Link
              to='/products/categories/graphics-cards'
              className='group inline-flex items-center gap-2 rounded-md bg-theme-crimson px-7 py-3.5 font-semibold text-theme-white shadow-lg shadow-theme-crimson/25 transition-colors duration-200 hover:bg-theme-lightcrimson focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-theme-crimson'
            >
              {hero.primaryCta}
              <ArrowRight
                size={18}
                className='transition-transform duration-200 group-hover:translate-x-1 motion-reduce:transition-none'
              />
            </Link>
            <a
              href='#categories'
              className='inline-flex items-center rounded-md border border-white/15 px-7 py-3.5 font-semibold text-theme-white transition-colors duration-200 hover:border-theme-crimson hover:text-theme-crimson focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-theme-crimson'
            >
              {hero.secondaryCta}
            </a>
          </div>

          <ul className='mt-10 flex flex-wrap items-center gap-x-3 gap-y-2 text-xs font-medium uppercase tracking-wider text-gray-500'>
            <li>{hero.metaOriginal}</li>
            <li aria-hidden className='h-1 w-1 rounded-full bg-theme-crimson' />
            <li>{hero.metaWarranty}</li>
            <li aria-hidden className='h-1 w-1 rounded-full bg-theme-crimson' />
            <li>{hero.metaDelivery}</li>
          </ul>
        </div>

        <div className='relative hidden lg:block'>
          <SpecBoard />
        </div>
      </div>
    </section>
  );
}

const chips: { Icon: LucideIcon; label: string }[] = [
  { Icon: Cpu, label: 'CPU' },
  { Icon: Gpu, label: 'GPU' },
  { Icon: MemoryStick, label: 'RAM' },
  { Icon: HardDrive, label: 'SSD' },
];

/**
 * Signature element: a "spec sheet" board that frames the store's world —
 * the core components, wired onto a board, with registration marks borrowed
 * from a parts catalogue. Purely decorative, so it carries no translatable copy.
 */
function SpecBoard() {
  return (
    <div className='relative mx-auto aspect-square w-full max-w-md rounded-2xl border border-white/10 bg-theme-gunmetal p-6 shadow-2xl'>
      <span
        aria-hidden
        className='absolute left-3 top-3 h-3 w-3 border-l-2 border-t-2 border-theme-crimson/60'
      />
      <span
        aria-hidden
        className='absolute right-3 top-3 h-3 w-3 border-r-2 border-t-2 border-theme-crimson/60'
      />
      <span
        aria-hidden
        className='absolute bottom-3 left-3 h-3 w-3 border-b-2 border-l-2 border-theme-crimson/60'
      />
      <span
        aria-hidden
        className='absolute bottom-3 right-3 h-3 w-3 border-b-2 border-r-2 border-theme-crimson/60'
      />

      <div className='mb-6 flex items-center justify-between border-b border-white/10 pb-4'>
        <span className='text-sm font-bold uppercase tracking-[0.3em] text-theme-white'>
          digite<span className='text-theme-crimson'>x</span>
        </span>
        <span aria-hidden className='flex items-center gap-1.5'>
          <span className='h-1.5 w-1.5 rounded-full bg-white/20' />
          <span className='h-1.5 w-1.5 rounded-full bg-white/20' />
          <span className='h-1.5 w-1.5 rounded-full bg-theme-crimson' />
        </span>
      </div>

      <div className='grid grid-cols-2 gap-4'>
        {chips.map(({ Icon, label }) => (
          <div
            key={label}
            className='flex aspect-square flex-col items-center justify-center gap-3 rounded-xl border border-white/8 bg-theme-eerie-black'
          >
            <Icon size={34} strokeWidth={1.5} className='text-theme-crimson' />
            <span className='text-xs font-semibold uppercase tracking-widest text-gray-400'>
              {label}
            </span>
          </div>
        ))}
      </div>
    </div>
  );
}
