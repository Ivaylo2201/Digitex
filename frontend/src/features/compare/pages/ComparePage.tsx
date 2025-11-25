import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useCompare } from '../stores/useCompare';
import { ProcessorCompareTable } from '../components/tables/ProcessorsCompareTable';
import { MonitorsCompareTable } from '../components/tables/MonitorsCompareTable';
import { Page } from '@/components/layout/Page';
import { GraphicsCardsCompareTable } from '../components/tables/GraphicsCardsCompareTable';
import MotherboardsCompareTable from '../components/tables/MotherboardsCompareTable';
import { RamsCompareTable } from '../components/tables/RamsCompareTable';
import { SsdsCompareTable } from '../components/tables/SsdsCompareTable';
import PowerSuppliesCompareTable from '../components/tables/PowerSuppliesCompareTable';
import { Button } from '@/components/ui/button';
import {
  Empty,
  EmptyHeader,
  EmptyMedia,
  EmptyTitle,
  EmptyDescription,
  EmptyContent
} from '@/components/ui/empty';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { MonitorX, ArrowUpRightIcon } from 'lucide-react';
import { useNavigate } from 'react-router';

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
        <EmptyComparePage />
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

function EmptyComparePage() {
  const {
    components: { emptyComparePage }
  } = useTranslation();
  const navigate = useNavigate();

  return (
    <Empty>
      <EmptyHeader>
        <EmptyMedia variant='icon'>
          <MonitorX />
        </EmptyMedia>
        <EmptyTitle>{emptyComparePage.noProductsAddedForComparison}</EmptyTitle>
        <EmptyDescription>
          <p>{emptyComparePage.youHaveNotAddedAnyProductsForComparisonYet}</p>
          <p className='flex justify-center items-center gap-1.5'>
            {emptyComparePage.getStartedByAddingAProduct}
          </p>
        </EmptyDescription>
      </EmptyHeader>
      <EmptyContent>
        <Button
          onClick={() => navigate('/products/categories/graphics-cards')}
          className='bg-theme-gunmetal cursor-pointer'
        >
          {emptyComparePage.addProducts}
          <ArrowUpRightIcon />
        </Button>
      </EmptyContent>
    </Empty>
  );
}
