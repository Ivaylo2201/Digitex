import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { ProductPageBreadcrumb } from '../../components/ProductCard/ProductPageBreadcrumb';
import { Page } from '@/components/layout/Page';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import { Button } from '@/components/ui/button';
import { ShoppingCart } from 'lucide-react';
import type { Spec } from '../../models/shared/Spec';
import { Rating } from '../../components/Rating';
import { SuggestedProducts } from './components/SuggestedProducts';
import { Reviews } from './components/Reviews';
import { AddToCompareButton } from './components/AddToCompareButton';
import { SpecsTable } from './components/SpecsTable';
import { ProductPrice } from './components/ProductPrice';
import { AddToFavoritesButton } from './components/AddToFavoritesButton';

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
  const displayName = `${product.brandName} ${product.modelName}`;

  return (
    <Page>
      <section className='flex flex-col gap-8'>
        <div className='flex flex-col gap-8 md:flex-row md:gap-25'>
          <div className='flex flex-col gap-8'>
            <ProductPageBreadcrumb
              category={category}
              displayName={displayName}
              translation={translation}
            />

            <div className='flex justify-between'>
              <img
                src={getStaticFile(product.imagePath)}
                alt={displayName}
                className='w-full min-w-60 max-w-xl h-auto object-contain'
              />

              <div className='flex flex-col gap-4'>
                <AddToCompareButton
                  product={product}
                  category={category}
                  translation={translation}
                />
                <AddToFavoritesButton />
              </div>
            </div>
          </div>

          <div className='flex flex-col gap-5'>
            <div className='flex flex-col gap-2'>
              <p className='w-100 text-2xl md:text-3xl text-theme-gunmetal font-bold'>
                {displayName}
              </p>
              <div className='flex justify-between items-center'>
                <ProductPrice product={product} />
                <div className='flex items-center gap-2'>
                  <Rating stars={product.rating} starSize={20} />
                  <span className='font-medium text-theme-gunmetal'>
                    ({product.totalReviews})
                  </span>
                </div>
              </div>
            </div>

            <div className='flex flex-col gap-6'>
              <SpecsTable specs={specs} translation={translation} />
              <Button className='bg-theme-crimson hover:bg-theme-gunmetal transition-colors duration-300 cursor-pointer'>
                <ShoppingCart />
                {translation.keywords.addToCart}
              </Button>
            </div>
          </div>
        </div>

        <SuggestedProducts
          suggestedProducts={product.suggestedProducts}
          translation={translation}
        />
        <Reviews reviews={product.recentReviews} translation={translation} />
      </section>
    </Page>
  );
}
