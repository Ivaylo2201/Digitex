import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useCompare } from '../stores/useCompare';
import ProcessorCompareTable from '../components/ProcessorsCompareTable';
import MonitorsCompareTable from '../components/MonitorsCompareTable';
import Page from '@/components/layout/Page';
import GraphicsCardCompareTable from '../components/GraphicsCardCompareTable';
import { Button } from '@/components/ui/button';
import { Trash } from 'lucide-react';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';

const compareTables: Record<
  string,
  React.ComponentType<{ products: ProductLong[] }>
> = {
  processors: ProcessorCompareTable,
  monitors: MonitorsCompareTable,
  'graphics-cards': GraphicsCardCompareTable
};

export default function ComparePage() {
  const { category, products, clearCompare } = useCompare();
  const translation = useTranslation();

  if (!category || !(category in compareTables)) {
    return <Page>Nothing to compare</Page>;
  }

  const CompareTable = compareTables[category];

  return (
    <Page>
      <section className='flex flex-col gap-4'>
        <Button
          className='inline-flex bg-theme-gunmetal hover:bg-gray-400 rounded-full items-center justify-center cursor-pointer w-max'
          onClick={clearCompare}
        >
          <Trash />
          <p>{translation.compare.clear}</p>
        </Button>
        <CompareTable products={products} />
      </section>
    </Page>
  );
}
