import { Page } from '@/components/layout/Page';
import { useFavorites } from '../hooks/useFavorites';
import { FavoritesList } from '../components/FavoritesList';

export function FavoritesPage() {
  const { data } = useFavorites();

  return (
    <Page>
      <FavoritesList products={data} />
    </Page>
  );
}
