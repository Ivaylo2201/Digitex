import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { ProductPageBreadcrumb } from '../../components/ProductCard/ProductPageBreadcrumb';
import { Page } from '@/components/layout/Page';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import type { Specification } from '../../models/shared/Specification';
import { Rating } from '../../components/Rating';
import { SuggestedProductsSection } from './components/SuggestedProductsSection';
import { ReviewsSection } from './components/ReviewsSection';
import { AddToCompareButton } from './components/AddToCompareButton';
import { SpecificationsTable } from './components/SpecificationsTable';
import { ProductPrice } from './components/ProductPrice';
import { AddToFavoritesButton } from './components/AddToFavoritesButton';
import { AddToCartButton } from './components/AddToCartButton';

type ProductPageProps<T extends ProductLong> = {
  category: string;
  product: T;
  specifications: Specification[];
};

export function ProductPage<T extends ProductLong>({
  category,
  product,
  specifications
}: ProductPageProps<T>) {
  const displayName = `${product.brandName} ${product.modelName}`;

  return (
    <Page>
      <section className='flex flex-col gap-8'>
        <div className='flex flex-col gap-8 md:flex-row md:gap-25'>
          <div className='flex flex-col gap-8'>
            <ProductPageBreadcrumb
              category={category}
              displayName={displayName}
            />

            <div className='flex justify-between'>
              <img
                src={getStaticFile(product.imagePath)}
                alt={displayName}
                className='w-full min-w-60 max-w-xl h-auto object-contain'
              />

              <div className='flex flex-col gap-4'>
                <AddToCompareButton product={product} category={category} />
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
              <SpecificationsTable specifications={specifications} />
              <AddToCartButton />
            </div>
          </div>
        </div>

        <SuggestedProductsSection
          suggestedProducts={product.suggestedProducts}
        />
        <ReviewsSection reviews={product.recentReviews} />
      </section>
    </Page>
  );
}
