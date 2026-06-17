import { Truck, ShieldCheck, Cable, Headset, type LucideIcon } from 'lucide-react';
import { useTranslation } from '@/features/language/hooks/useTranslation';

export function ValueProps() {
  const { home } = useTranslation();
  const { valueProps } = home;

  const items: { Icon: LucideIcon; title: string; text: string }[] = [
    {
      Icon: Truck,
      title: valueProps.shippingTitle,
      text: valueProps.shippingText,
    },
    {
      Icon: ShieldCheck,
      title: valueProps.warrantyTitle,
      text: valueProps.warrantyText,
    },
    {
      Icon: Cable,
      title: valueProps.compatibilityTitle,
      text: valueProps.compatibilityText,
    },
    {
      Icon: Headset,
      title: valueProps.supportTitle,
      text: valueProps.supportText,
    },
  ];

  return (
    <section className='border-y border-white/8 bg-theme-gunmetal px-6 py-16 md:py-20'>
      <div className='mx-auto grid max-w-7xl grid-cols-1 gap-10 sm:grid-cols-2 lg:grid-cols-4'>
        {items.map(({ Icon, title, text }) => (
          <div key={title} className='flex flex-col gap-3'>
            <Icon
              size={26}
              strokeWidth={1.75}
              className='text-theme-crimson'
            />
            <h3 className='font-bold text-theme-white'>{title}</h3>
            <p className='text-sm leading-relaxed text-gray-400'>{text}</p>
          </div>
        ))}
      </div>
    </section>
  );
}
