import { useTranslation } from '@/features/language/hooks/useTranslation';
import { homeCategories } from '../data/categories';
import { CategoryCard } from './CategoryCard';

export function CategoriesSection() {
  const { home, routeNames } = useTranslation();
  const { categories } = home;

  return (
    <section
      id='categories'
      className='scroll-mt-24 bg-theme-eerie-black px-6 py-20 md:py-24'
    >
      <div className='mx-auto max-w-7xl'>
        <header className='mb-12 max-w-2xl'>
          <h2 className='text-3xl font-extrabold tracking-tight text-theme-white sm:text-4xl'>
            {categories.heading}
          </h2>
          <p className='mt-3 text-base text-gray-400'>
            {categories.subheading}
          </p>
        </header>

        <div className='grid grid-cols-2 gap-4 md:grid-cols-3 lg:grid-cols-4'>
          {homeCategories.map((category) => (
            <CategoryCard
              key={category.slug}
              to={`/products/categories/${category.slug}`}
              label={routeNames[category.routeKey]}
              Icon={category.icon}
            />
          ))}
        </div>
      </div>
    </section>
  );
}
