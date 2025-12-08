import { ProductCard } from '@/features/products/components/ProductCard/ProductCard';
import type { ProductShort } from '@/features/products/models/base/ProductShort';

type ProductsListProps = { products: ProductShort[]; category: string };

export function ProductsList({ products, category }: ProductsListProps) {
  return (
    <div className='grid grid-cols-1 sm:grid-cols-2 md:grid-cols-2 xl:grid-cols-3 items-center gap-x-6 gap-y-12'>
      {products.map((product) => (
        <ProductCard key={product.id} {...product} category={category} />
      ))}
    </div>
  );
}
