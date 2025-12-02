import type { SuggestedProduct } from '@/features/products/models/shared/SuggestedProduct';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import { Link } from 'react-router';
import { Separator } from '@/components/ui/separator';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { EmptySuggestedProductsSection } from './EmptySuggestedProductsSection';

type SuggestedProductsSectionProps = {
  suggestedProducts: SuggestedProduct[];
};

export function SuggestedProductsSection({
  suggestedProducts,
}: SuggestedProductsSectionProps) {
  const {
    components: { suggestedProductsSection },
  } = useTranslation();
  const hasProducts = suggestedProducts.length > 0;

  return (
    <section className='flex flex-col'>
      <p className='text-xl font-semibold text-theme-gunmetal'>
        {suggestedProductsSection.suggestedProducts}
      </p>

      <Separator
        orientation='horizontal'
        className='bg-gray-300 h-px mt-2 mb-4'
      />

      <div>
        {hasProducts ? (
          suggestedProducts.map((product) => (
            <Link
              key={product.id}
              to={`/products/${product.category}/${product.id}`}
              className='group flex items-center gap-4 cursor-pointer'
            >
              <div className='w-16 h-16 overflow-hidden'>
                <img
                  src={getStaticFile(product.imagePath)}
                  className='w-full h-full object-contain transition-transform duration-200 group-hover:scale-110'
                />
              </div>

              <p className='truncate max-w-[255px] group-hover:text-theme-crimson transition-colors duration-200'>
                {product.brandName} {product.modelName}
              </p>
            </Link>
          ))
        ) : (
          <EmptySuggestedProductsSection />
        )}
      </div>
    </section>
  );
}
