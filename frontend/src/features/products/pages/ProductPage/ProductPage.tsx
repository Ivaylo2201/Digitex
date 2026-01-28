import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { ProductPageBreadcrumb } from '../../components/ProductCard/ProductPageBreadcrumb';
import { Page } from '@/components/layout/Page';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import type { Specification } from '../../models/shared/Specification';
import { Rating } from '../../components/Rating';
import { SuggestedProductsSection } from './components/SuggestedProductsSection';
import { AddToCompareButton } from '../../../compare/components/AddToCompareButton';
import { SpecificationsTable } from './components/SpecificationsTable';
import { ProductPrice } from './components/ProductPrice';
import { AddToFavoritesButton } from '../../../favorites/components/AddToFavoritesButton';
import { ReviewsSection } from '@/features/reviews/components/ReviewsSection';
import { AddToCartButton } from '@/features/cart/components/AddToCartButton';
import { QuantityControlButtons } from './components/QuantityControlButtons';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { Loader } from '../../components/Loader';
import { useQuantityControl } from '../../hooks/useQuantityControl';
import { ReviewForm } from '@/features/reviews/components/ReviewForm';

type ProductPageProps<T extends ProductLong> = {
  category: string;
  product: T | undefined;
  onFormatSpecifications: (product: T) => Specification[];
};

export function ProductPage<T extends ProductLong>({
  category,
  product,
  onFormatSpecifications,
}: ProductPageProps<T>) {
  const quantityControl = useQuantityControl(1, product?.quantity ?? 0);

  const {
    components: { productPage },
  } = useTranslation();

  if (!product) {
    return (
      <Page>
        <Loader />
      </Page>
    );
  }

  const isInStock = product.quantity > 0;
  const displayName = `${product.brandName} ${product.modelName}`;
  const specifications = onFormatSpecifications(product);

  return (
    <Page>
      <section className='flex flex-col gap-8 '>
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
              <p className='text-theme-gunmetal text-sm font-semibold'>
                {productPage.sku}:&nbsp;
                <span className='text-gray-500 font-medium italic'>
                  {product.sku}
                </span>
              </p>
              <div className='flex justify-between items-center'>
                <ProductPrice product={product} />
                <div className='flex items-center gap-1'>
                  <Rating stars={product.rating} starSize={20} />
                  <span className='font-medium text-theme-gunmetal'>
                    ({product.totalReviews})
                  </span>
                </div>
              </div>
            </div>

            <SpecificationsTable specifications={specifications} />

            <div className='flex justify-center items-center gap-8'>
              <QuantityControlButtons
                maxQuantity={product.quantity}
                {...quantityControl}
              />
              <AddToCartButton
                isInStock={isInStock}
                quantity={quantityControl.quantity}
                productId={product.id}
              />
            </div>
          </div>
        </div>

        <SuggestedProductsSection suggestedProducts={[]} />
        <ReviewsSection productId={product.id} reviews={[]} />
      </section>
    </Page>
  );
}
