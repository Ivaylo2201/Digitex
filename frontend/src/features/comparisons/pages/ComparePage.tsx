import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useCompare } from '../stores/useCompare';
import ProcessorCompareTable from '../components/ProcessorsCompareTable';
import MonitorsCompareTable from '../components/MonitorsCompareTable';
import Page from '@/components/layout/Page';

const compareTables: Record<
  string,
  React.ComponentType<{ products: ProductLong[] }>
> = {
  processors: ProcessorCompareTable,
  monitors: MonitorsCompareTable
};

export default function ComparePage() {
  const { category, products } = useCompare();

  if (!category || !(category in compareTables)) {
    return <Page>Nothing to compare</Page>;
  }

  const CompareTable = compareTables[category];

  return (
    <Page>
      <CompareTable products={products} />
    </Page>
  );
}
