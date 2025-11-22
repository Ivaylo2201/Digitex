import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableRow
} from '@/components/ui/table';

import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { ProductPageBreadcrumb } from '../components/ProductCard/ProductPageBreadcrumb';
import { Page } from '@/components/layout/Page';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import { Button } from '@/components/ui/button';
import { Minus, Plus, ShoppingCart } from 'lucide-react';
import { useCurrencyExchange } from '@/features/currency/hooks/useCurrencyExchange';
import { Separator } from '@/components/ui/separator';
import { useState } from 'react';
import CompareToggleCheckbox from '../components/CompareToggleCheckbox';
import { Link } from 'react-router';
import type { Spec } from '../models/shared/Spec';

type ProductPageProps<T extends ProductLong> = {
  category: string;
  product: T;
  specs: Spec[];
};

export function ProductPage<T extends ProductLong>({
  category,
  product,
  specs
}: ProductPageProps<T>) {
  const [quantity, setQuantity] = useState(1);
  const translation = useTranslation();
  const { exchangeCurrency } = useCurrencyExchange();

  const displayName = `${product.brandName} ${product.modelName}`;
  const exchangedDiscountedPrice = exchangeCurrency(product.price.discounted);
  const exchangedInitialPrice = exchangeCurrency(product.price.initial);
  const exchangedPriceDifference = exchangeCurrency(product.price.initial - product.price.discounted);

  return (
    <Page>
      <section className='flex flex-col gap-4 md:w-2/3'>
        <ProductPageBreadcrumb category={category} displayName={displayName} />

        <div className='flex flex-col gap-14'>
          <p className='text-2xl md:text-4xl text-theme-gunmetal font-bold'>
            {displayName}
          </p>
          <img
            src={getStaticFile(product.imagePath)}
            alt={displayName}
            className='object-contain max-w-140'
          />

          <div className='bg-gray-200 border border-gray-300 flex flex-col gap-4 py-6 items-center rounded-lg'>
            <section className='flex flex-col justify-center items-center'>
              <p className='text-theme-crimson text-5xl font-semibold'>
                {exchangedDiscountedPrice}
              </p>
              {product.discountPercentage > 0 && (
                <>
                  <p className='text-gray-500 line-through'>
                    {exchangedInitialPrice}
                  </p>
                  <p className='text-sm font-medium text-theme-gunmetal'>
                    You are saving{' '}
                    <span className='text-theme-crimson font-semibold'>
                      {exchangedPriceDifference}
                    </span>{' '}
                    (-
                    {product.discountPercentage}%)
                  </p>
                </>
              )}
            </section>
            <Separator orientation='horizontal' className='bg-gray-300 h-px' />

            <section className='flex gap-4 justify-center items-center'>
              <div className='flex justify-center items-center gap-3'>
                <Button className='p-2 h-10 w-10 rounded-full bg-theme-gunmetal'>
                  <Plus />
                </Button>

                <p className='font-medium text-theme-gunmetal'>{quantity}</p>

                <Button className='p-2 h-10 w-10 rounded-full bg-theme-gunmetal cursor-pointer hover:bg-theme-crimson transition-colors duration-200'>
                  <Minus color='white' />
                </Button>
              </div>

              <Button className='bg-theme-gunmetal'>
                <ShoppingCart />
                Add to cart
              </Button>
            </section>
          </div>

          <CompareToggleCheckbox
            product={product}
            category={category}
            translation={translation}
          />

          <section className='overflow-x-auto py-4'>
            <Table className='font-montserrat border border-gray-200'>
              <TableCaption>
                {translation.keywords.mainSpecifications}
              </TableCaption>
              <TableBody className='text-theme-gunmetal'>
                {specs.map((item, index) => (
                  <TableRow
                    className={`pointer-events-none ${
                      index % 2 === 0 ? 'bg-gray-100' : ''
                    }`}
                    key={index}
                  >
                    <TableCell className='w-1/2'>{item.spec}</TableCell>
                    <TableCell className='w-1/2 font-medium'>
                      {item.value}
                    </TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </section>
        </div>

        <section className='bg-theme-gunmetal flex'>
          {product.suggestedProducts.map((suggestedProduct) => (
            <Link
              to={`/products/${suggestedProduct.category}/${suggestedProduct.id}`}
              className='bg-white rounded-xl'
            >
              <p>
                {suggestedProduct.brandName} {suggestedProduct.modelName}
              </p>
              <img
                className='size-10'
                src={getStaticFile(suggestedProduct.imagePath)}
              />
            </Link>
          ))}
        </section>
      </section>
    </Page>
  );
}
