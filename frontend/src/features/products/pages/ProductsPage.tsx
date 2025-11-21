import { useParams } from 'react-router';
import { Page } from '@/components/layout/Page';
import { ProductCard } from '@/features/products/components/ProductCard/ProductCard';
import { useProducts } from '../hooks/useProducts';
import { Spinner } from '@/components/ui/spinner';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';

export function ProductsPage() {
  const { category } = useParams<{ category: string }>();
  const { data: products } = useProducts(category);
  const translation = useTranslation();

  if (products === undefined || category === undefined) {
    return (
      <Page>
        <div className='flex justify-center items-center gap-2'>
          <Spinner className='size-8 text-theme-crimson' />
          <span className='font-medium text-theme-gunmetal'>{translation.keywords.loading}...</span>
        </div>
      </Page>
    );
  }

  return (
    <Page>
      <div className='grid grid-cols-1 sm:grid-cols-2 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 items-center gap-x-6 gap-y-12'>
        {products.map((product, index) => (
          <ProductCard key={index} {...product} category={category} />
        ))}
      </div>
    </Page>
  );
}
