import { useParams } from 'react-router';
import Page from './Page';
import useProducts from '@/lib/hooks/useProducts';
import ProductCard from '../shared/productCard/ProductCard';

type ProductsPageProps = {};

export default function ProductsPage({}: ProductsPageProps) {
  const { category } = useParams<{ category: string }>();
  const { data: products } = useProducts(category);

  return (
    <Page>
      <div className='grid grid-cols-4 gap-x-6'>
        {products.map((product) => (
          <ProductCard {...product} />
        ))}
      </div>
    </Page>
  );
}
