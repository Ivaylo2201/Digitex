import { useTranslation } from '@/features/language/hooks/useTranslation';
import { ProductCard } from '@/features/products/components/ProductCard/ProductCard';
import type { ProductShort } from '@/features/products/models/base/ProductShort';

type ProductsListProps = { products: ProductShort[]; category: string };

export function ProductsList({ products, category }: ProductsListProps) {
  const {
    components: { productsList },
  } = useTranslation();

  return (
    <div className='w-[1200px] mx-auto'>
      {products.length ? (
        <div className='grid grid-cols-1 sm:grid-cols-2 md:grid-cols-2 xl:grid-cols-3 gap-x-6 gap-y-12'>
          {products.map((product) => (
            <ProductCard key={product.id} {...product} category={category} />
          ))}
        </div>
      ) : (
        <div className='text-center py-16'>
          <p className='text-lg font-medium text-theme-crimson'>{productsList.noProductsFound}</p>
        </div>
      )}
    </div>
  );
}
