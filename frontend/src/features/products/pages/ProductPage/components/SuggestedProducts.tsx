import { type Translation } from '@/lib/i18n/models/Translation';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import { Link } from 'react-router';
import { Separator } from '@/components/ui/separator';
import {
  Empty,
  EmptyDescription,
  EmptyHeader,
  EmptyMedia,
  EmptyTitle
} from '@/components/ui/empty';
import { MonitorX } from 'lucide-react';
import type { SuggestedProduct } from '@/features/products/models/shared/SuggestedProduct';

type SuggestedProductsProps = {
  suggestedProducts: SuggestedProduct[];
  translation: Translation;
};

export function SuggestedProducts({
  suggestedProducts,
  translation
}: SuggestedProductsProps) {
  console.log(suggestedProducts);
  const hasProducts = suggestedProducts.length > 0;

  return (
    <section className='flex flex-col'>
      <p className='text-xl font-semibold text-theme-gunmetal'>
        {translation.keywords.suggestedProducts}
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
          <EmptySuggestedProducts />
        )}
      </div>
    </section>
  );
}

function EmptySuggestedProducts() {
  return (
    <Empty>
      <EmptyHeader>
        <EmptyMedia variant='icon'>
          <MonitorX />
        </EmptyMedia>
        <EmptyTitle>No suggested products available</EmptyTitle>
        <EmptyDescription>
          <p>This product has no suggestions yet.</p>
        </EmptyDescription>
      </EmptyHeader>
    </Empty>
  );
}
