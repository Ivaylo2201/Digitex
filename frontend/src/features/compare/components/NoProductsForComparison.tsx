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
import { ArrowUpRightIcon, MonitorX } from 'lucide-react';
import { useNavigate } from 'react-router';

export function NoProductsForComparison() {
  const translation = useTranslation();
  const navigate = useNavigate();

  return (
    <Empty>
      <EmptyHeader>
        <EmptyMedia variant='icon'>
          <MonitorX />
        </EmptyMedia>
        <EmptyTitle>
          {translation.compare.noProductsForComparison.title}
        </EmptyTitle>
        <EmptyDescription>
          <p>{translation.compare.noProductsForComparison.main}</p>
          <p className='flex justify-center items-center gap-1.5'>
            {translation.compare.noProductsForComparison.getStarted}
          </p>
        </EmptyDescription>
      </EmptyHeader>
      <EmptyContent>
        <Button
          onClick={() => navigate('/products/categories/graphics-cards')}
          className='bg-theme-gunmetal cursor-pointer'
        >
          {translation.compare.noProductsForComparison.addProducts}{' '}
          <ArrowUpRightIcon />
        </Button>
      </EmptyContent>
    </Empty>
  );
}
