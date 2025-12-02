import {
  Empty,
  EmptyHeader,
  EmptyMedia,
  EmptyTitle,
  EmptyDescription,
  EmptyContent,
} from '@/components/ui/empty';

import { Page } from '@/components/layout/Page';
import { Button } from '@/components/ui/button';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { ArrowUpRightIcon, MonitorX } from 'lucide-react';
import { useNavigate } from 'react-router';

export function EmptyComparePage() {
  const {
    components: { emptyComparePage },
  } = useTranslation();
  const navigate = useNavigate();

  return (
    <Page>
      <Empty>
        <EmptyHeader>
          <EmptyMedia variant='icon'>
            <MonitorX />
          </EmptyMedia>
          <EmptyTitle>
            {emptyComparePage.noProductsAddedForComparison}
          </EmptyTitle>
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
    </Page>
  );
}
