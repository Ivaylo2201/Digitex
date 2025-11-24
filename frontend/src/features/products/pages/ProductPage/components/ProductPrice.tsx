import { useCurrencyExchange } from '@/features/currency/hooks/useCurrencyExchange';
import type { ProductLong } from '@/features/products/models/base/ProductLong';

type ProductPriceProps = { product: ProductLong };

export function ProductPrice({ product }: ProductPriceProps) {
  const { exchangeCurrency } = useCurrencyExchange();
  const exchangedDiscountedPrice = exchangeCurrency(product.price.discounted);
  const exchangedInitialPrice = exchangeCurrency(product.price.initial);

  return (
    <div className='flex justify-center items-center gap-2'>
      <p className='text-theme-crimson text-2xl font-bold'>
        {exchangedDiscountedPrice}
      </p>
      {product.discountPercentage > 0 && (
        <p className='text-gray-500 text-lg line-through'>
          {exchangedInitialPrice}
        </p>
      )}
    </div>
  );
}
