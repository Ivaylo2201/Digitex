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
import { ArrowLeftRight, Heart, ShoppingCart } from 'lucide-react';
import { useCurrencyExchange } from '@/features/currency/hooks/useCurrencyExchange';
import { Link } from 'react-router';
import type { Spec } from '../models/shared/Spec';
import { Rating } from '../components/Rating';
import { useCompare } from '@/features/compare/stores/useCompare';
import { toast } from 'sonner';
import { Separator } from '@/components/ui/separator';
import { ScrollArea } from '@/components/ui/scroll-area';

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
  const translation = useTranslation();
  const { exchangeCurrency } = useCurrencyExchange();
  const { addToCompare } = useCompare();

  const displayName = `${product.brandName} ${product.modelName}`;
  const exchangedDiscountedPrice = exchangeCurrency(product.price.discounted);
  const exchangedInitialPrice = exchangeCurrency(product.price.initial);

  const handleAddToCompare = () => {
    const addToCompareResult = addToCompare(
      { ...product, category },
      translation
    );

    if (addToCompareResult.isSuccess) {
      toast.success(addToCompareResult.message);
    } else {
      toast.error(addToCompareResult.message);
    }
  };

  return (
    <Page>
      <section className='flex flex-col gap-8'>
        <section className='flex flex-col gap-8'>
          <ProductPageBreadcrumb
            category={category}
            displayName={displayName}
          />
          <div className='flex justify-between'>
            <img
              src={getStaticFile(product.imagePath)}
              alt={displayName}
              className='w-[300px] h-[200px] object-contain' // TODO: adjust
            />

            <div className='flex flex-col gap-4'>
              <Button
                onClick={handleAddToCompare}
                className='bg-theme-gunmetal hover:bg-theme-crimson transition-colors duration-300 cursor-pointer'
              >
                <ArrowLeftRight />
              </Button>
              <Button className='bg-theme-gunmetal hover:bg-theme-crimson transition-colors duration-300 cursor-pointer'>
                <Heart />
              </Button>
            </div>
          </div>
        </section>

        <section className='flex flex-col gap-2'>
          <p className='w-100 text-2xl md:text-3xl text-theme-gunmetal font-bold'>
            {displayName}
          </p>
          <div className='flex justify-between items-center'>
            <div className='flex justify-center items-center gap-2'>
              <p className='text-theme-crimson text-2xl font-bold'>
                {exchangedDiscountedPrice}
              </p>
              {product.discountPercentage > 0 && (
                <p className='text-gray-500 text- line-through'>
                  {exchangedInitialPrice}
                </p>
              )}
            </div>
            <div className='flex justify-center items-center'>
              <Rating stars={product.rating} starSize={20} />
              <span className='font-medium text-theme-gunmetal'>
                ({product.totalReviews})
              </span>
            </div>
          </div>
        </section>

        <section className='overflow-x-auto flex flex-col gap-6'>
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
          <Button className='bg-theme-crimson hover:bg-theme-gunmetal transition-colors duration-300 cursor-pointer'>
            <ShoppingCart />
            {translation.keywords.addToCart}
          </Button>
        </section>

        <section className='flex flex-col'>
          <p className='text-xl font-semibold text-theme-gunmetal'>
            {translation.keywords.suggestedProducts}
          </p>
          <Separator
            orientation='horizontal'
            className='bg-gray-300 h-px mt-2 mb-4'
          />
          {product.suggestedProducts.map((suggestedProduct) => (
            <Link
              to={`/products/${suggestedProduct.category}/${suggestedProduct.id}`}
              className='group flex items-center gap-4 cursor-pointer'
            >
              <div className='w-16 h-16 overflow-hidden'>
                <img
                  className='w-full h-full object-contain transition-transform duration-200 group-hover:scale-110'
                  src={getStaticFile(suggestedProduct.imagePath)}
                />
              </div>
              <p className='truncate max-w-[255px] group-hover:text-theme-crimson transition-colors duration-200'>
                {suggestedProduct.brandName} {suggestedProduct.modelName}
              </p>
            </Link>
          ))}
        </section>

        <section className='flex flex-col'>
          <p className='text-xl font-semibold text-theme-gunmetal'>
            {translation.keywords.reviews}
          </p>
          <Separator
            orientation='horizontal'
            className='bg-gray-300 h-px mt-2 mb-4'
          />
          <ScrollArea className='h-72'>
            <div className='flex flex-col gap-4'>
              {Array.from({ length: 100 }).map((_, index) => (
                <article key={index} className='p-1 flex flex-col gap-2'>
                  <div className='flex flex-col'>
                    <p className='font-medium'>John doe {index}</p>
                    <Rating stars={4} starSize={13} />
                  </div>
                  <p className='max-w-110 text-gray-500 text-sm'>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit.
                    Officiis libero.
                  </p>
                </article>
              ))}
            </div>
          </ScrollArea>
        </section>
      </section>
    </Page>
  );
}
