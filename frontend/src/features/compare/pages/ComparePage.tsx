import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useCompare } from '../stores/useCompare';
import { ProcessorCompareTable } from '../components/tables/ProcessorsCompareTable';
import { MonitorsCompareTable } from '../components/tables/MonitorsCompareTable';
import { Page } from '@/components/layout/Page';
import { GraphicsCardsCompareTable } from '../components/tables/GraphicsCardsCompareTable';
import { NoProductsForComparison } from '../components/NoProductsForComparison';
import MotherboardsCompareTable from '../components/tables/MotherboardsCompareTable';
import { RamsCompareTable } from '../components/tables/RamsCompareTable';
import { SsdsCompareTable } from '../components/tables/SsdsCompareTable';
import PowerSuppliesCompareTable from '../components/tables/PowerSuppliesCompareTable';

const compareTables: Record<
  string,
  React.ComponentType<{ products: ProductLong[] }>
> = {
  processors: ProcessorCompareTable,
  monitors: MonitorsCompareTable,
  'graphics-cards': GraphicsCardsCompareTable,
  motherboards: MotherboardsCompareTable,
  rams: RamsCompareTable,
  ssds: SsdsCompareTable,
  'power-supplies': PowerSuppliesCompareTable
};

export function ComparePage() {
  const { category, products, clearCompare } = useCompare();

  if (!category || !(category in compareTables)) {
    return (
      <Page>
        <NoProductsForComparison />
      </Page>
    );
  }

  const CompareTable = compareTables[category];

  return (
    <Page>
      <section className='overflow-x-auto min-w-1/2'>
        <CompareTable products={products} />
      </section>
    </Page>
  );
}
