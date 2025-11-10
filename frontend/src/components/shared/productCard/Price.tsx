import useCurrencyExchange from '@/lib/hooks/useCurrencyExchange';
import type { Price } from '@/lib/models/price';
import React from 'react';

type PriceProps = {
  price: Price;
  discountPercentage: number;
};

export default function Price({ price, discountPercentage }: PriceProps) {
  const { exchangeCurrency } = useCurrencyExchange();

  const exchangedInitialPrice = exchangeCurrency(price.initial);
  const exchangedDiscountedPrice = exchangeCurrency(price.discounted);

  return (
    <React.Fragment>
      <p className='font-bold text-theme-crimson'>{exchangedDiscountedPrice}</p>
      {discountPercentage > 0 && (
        <p className='text-sm line-through text-gray-500'>
          {exchangedInitialPrice}
        </p>
      )}
    </React.Fragment>
  );
}
