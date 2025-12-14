import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';
import type { ProductLong } from '@/features/products/models/base/ProductLong';

type ProductPriceProps = { product: ProductLong };

export function ProductPrice({ product }: ProductPriceProps) {
  const { currency } = useCurrencyStore();

  return (
    <div className='flex justify-center items-center gap-2'>
      <p className='text-theme-crimson text-2xl font-bold'>
        {currency.sign}
        {product.price.discounted.toFixed(2)}
      </p>
      {product.discountPercentage > 0 && (
        <p className='text-gray-500 text-lg line-through'>
          {currency.sign}
          {product.price.initial.toFixed(2)}
        </p>
      )}
    </div>
  );
}
