import { Page } from '@/components/layout/Page';
import { Button } from '@/components/ui/button';
import {
  Empty,
  EmptyHeader,
  EmptyMedia,
  EmptyTitle,
  EmptyDescription,
  EmptyContent,
} from '@/components/ui/empty';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { ArrowUpRightIcon, X } from 'lucide-react';
import { useNavigate } from 'react-router';

export function EmptyCartPage() {
  const navigate = useNavigate();
  const {
    components: { emptyCartPage },
  } = useTranslation();

  return (
    <Page>
      <Empty>
        <EmptyHeader>
          <EmptyMedia variant='icon'>
            <X />
          </EmptyMedia>
          <EmptyTitle>{emptyCartPage.yourCartIsEmpty}</EmptyTitle>
          <EmptyDescription>
            <p>{emptyCartPage.youHaveNotAddedAnyItemsInYourCart}</p>
            <p className='flex justify-center items-center gap-1.5'>
              {emptyCartPage.GetStartedByAddingAnItem}
            </p>
          </EmptyDescription>
        </EmptyHeader>
        <EmptyContent>
          <Button
            onClick={() => navigate('/products/categories/graphics-cards')}
            className='bg-theme-gunmetal cursor-pointer'
          >
            {emptyCartPage.AddItems}
            <ArrowUpRightIcon />
          </Button>
        </EmptyContent>
      </Empty>
    </Page>
  );
}
