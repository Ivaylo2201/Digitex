import { ProductCard } from '@/features/products/components/ProductCard/ProductCard';
import type { ProductShort } from '@/features/products/models/base/ProductShort';
import { EmptyFavorites } from './EmptyFavorites';

type FavoritesListProps = {
  products: ProductShort[];
};

export function FavoritesList({ products }: FavoritesListProps) {
  return (
    <div className='w-[1200px] mx-auto'>
      {products.length ? (
        <div className='grid grid-cols-1 sm:grid-cols-2 md:grid-cols-2 xl:grid-cols-3 gap-x-6 gap-y-12'>
          {products.map((product) => (
            <ProductCard
              key={product.id}
              {...product}
              category={product.category ?? ''}
            />
          ))}
        </div>
      ) : (
        <div className='text-center py-16'>
          <EmptyFavorites />
        </div>
      )}
    </div>
  );
}
