import { useParams } from 'react-router';
import { Page } from '@/components/layout/Page';
import { useProducts } from '../../hooks/useProducts';
import { Loader } from './components/Loader';
import { ProductsList } from './components/ProductsList';

export function ProductsPage() {
  const { category } = useParams<{ category: string }>();
  const { data: products } = useProducts(category);
  const isLoading = products === undefined || category === undefined;

  return (
    <Page>
      {isLoading ? (
        <Loader />
      ) : (
        <ProductsList products={products} category={category} />
      )}
    </Page>
  );
}
