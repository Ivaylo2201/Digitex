import { Link } from 'react-router';
import { ArrowRight, type LucideIcon } from 'lucide-react';

type CategoryCardProps = {
  to: string;
  label: string;
  Icon: LucideIcon;
};

export function CategoryCard({ to, label, Icon }: CategoryCardProps) {
  return (
    <Link
      to={to}
      className='group relative flex flex-col gap-6 overflow-hidden rounded-xl border border-white/8 bg-theme-gunmetal p-6 transition-colors duration-200 hover:border-theme-crimson/60 focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-theme-crimson'
    >
      <span
        aria-hidden
        className='absolute inset-x-0 top-0 h-px w-0 bg-theme-crimson transition-all duration-300 group-hover:w-full motion-reduce:transition-none'
      />
      <span className='flex h-12 w-12 items-center justify-center rounded-lg bg-theme-eerie-black text-theme-crimson ring-1 ring-white/8 transition-transform duration-200 group-hover:scale-105 motion-reduce:transition-none'>
        <Icon size={24} strokeWidth={1.75} />
      </span>
      <div className='flex items-center justify-between'>
        <span className='font-semibold text-theme-white'>{label}</span>
        <ArrowRight
          size={18}
          className='text-gray-500 transition-all duration-200 group-hover:translate-x-1 group-hover:text-theme-crimson motion-reduce:transition-none'
        />
      </div>
    </Link>
  );
}
