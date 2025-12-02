import {
  Empty,
  EmptyHeader,
  EmptyMedia,
  EmptyTitle,
  EmptyDescription,
} from '@/components/ui/empty';

import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { MessageSquareX } from 'lucide-react';

export function EmptyReviewsSection() {
  const {
    components: { emptyReviewsSection },
  } = useTranslation();

  return (
    <Empty>
      <EmptyHeader>
        <EmptyMedia variant='icon'>
          <MessageSquareX />
        </EmptyMedia>
        <EmptyTitle>{emptyReviewsSection.noReviewsForThisProduct}</EmptyTitle>
        <EmptyDescription>
          <p>{emptyReviewsSection.noReviewsHaveBeenLeftForThisProductYet}</p>
          <p className='flex justify-center items-center gap-1.5'>
            {emptyReviewsSection.writeTheFirstReviewViaTheFormBelow}
          </p>
        </EmptyDescription>
      </EmptyHeader>
    </Empty>
  );
}
