import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useCompare } from '../stores/useCompare';
import { ProcessorCompareTable } from '../components/ProcessorsCompareTable';
import { MonitorsCompareTable } from '../components/MonitorsCompareTable';
import { Page } from '@/components/layout/Page';
import { GraphicsCardCompareTable } from '../components/GraphicsCardCompareTable';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';

const compareTables: Record<
  string,
  React.ComponentType<{ products: ProductLong[] }>
> = {
  processors: ProcessorCompareTable,
  monitors: MonitorsCompareTable,
  'graphics-cards': GraphicsCardCompareTable,
};

export function ComparePage() {
  const { category, products, clearCompare } = useCompare();
  const translation = useTranslation();

  if (!category || !(category in compareTables)) {
    return <Page>Nothing to compare</Page>;
  }

  const CompareTable = compareTables[category];

  return (
    <Page>
      <section className='overflow-x-auto w-3/4'>
        <CompareTable products={products} />
      </section>
    </Page>
  );
}
