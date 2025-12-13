import type { ProductLong } from '@/features/products/models/base/ProductLong';

type ProductPriceProps = { product: ProductLong };

export function ProductPrice({ product }: ProductPriceProps) {
  return (
    <div className='flex justify-center items-center gap-2'>
      <p className='text-theme-crimson text-2xl font-bold'>
        {product.price.discounted}
      </p>
      {product.discountPercentage > 0 && (
        <p className='text-gray-500 text-lg line-through'>
          {product.price.initial}
        </p>
      )}
    </div>
  );
}
