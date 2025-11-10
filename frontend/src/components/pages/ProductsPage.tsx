import { useParams } from 'react-router';
import Page from '@/components/pages/Page';
import useProducts from '@/lib/hooks/useProducts';
import ProductCard from '@/components/shared/productCard/ProductCard';

export default function ProductsPage() {
  const { category } = useParams<{ category: string }>();
  const { data: products } = useProducts(category);

  return (
    <Page>
      <div className='grid grid-cols-1 sm:grid-cols-2 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 items-center gap-x-6 gap-y-12'>
        {products.map((product, idx) => (
          <ProductCard key={idx} {...product} />
        ))}
      </div>
    </Page>
  );
}
