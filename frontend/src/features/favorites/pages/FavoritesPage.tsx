import { Page } from '@/components/layout/Page';
import { ProductsList } from '@/features/products/pages/ProductsPage/components/ProductsList';
import { useFavorites } from '../hooks/useFavorites';

export function FavoritesPage() {
  const { data } = useFavorites();

  return (
    <Page>
      <ProductsList products={data} category={''} />
    </Page>
  );
}
