import { ScrollArea } from '@/components/ui/scroll-area';
import { Separator } from '@/components/ui/separator';
import type { Review } from '@/features/reviews/models/Review';

import {
  Empty,
  EmptyHeader,
  EmptyMedia,
  EmptyTitle,
  EmptyDescription
} from '@/components/ui/empty';

import { MessageSquareX } from 'lucide-react';
import { Rating } from '@/features/products/components/Rating';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';

type ReviewsProps = {
  reviews: Review[];
};

export function Reviews({ reviews }: ReviewsProps) {
  const {
    components: { reviewsSections }
  } = useTranslation();
  const hasReviews = reviews.length > 0;

  return (
    <section className='flex flex-col'>
      <p className='text-xl font-semibold text-theme-gunmetal'>
        {reviewsSections.reviews}
      </p>
      <Separator
        orientation='horizontal'
        className='bg-gray-300 h-px mt-2 mb-4'
      />
      {hasReviews ? (
        <ScrollArea className='h-72'>
          <div className='flex md:grid md:grid-cols-2 md:items-center flex-col gap-4'>
            {Array.from({ length: 100 }).map((_, index) => (
              <article key={index} className='p-1 flex flex-col gap-2'>
                <div className='flex flex-col'>
                  <p className='font-medium'>John doe {index}</p>
                  <Rating stars={4} starSize={13} />
                </div>
                <p className='max-w-110 text-gray-500 text-sm'>
                  Lorem ipsum dolor sit amet consectetur adipisicing elit.
                  Officiis libero.
                </p>
              </article>
            ))}
          </div>
        </ScrollArea>
      ) : (
        <EmptyReviewsSection />
      )}
    </section>
  );
}

function EmptyReviewsSection() {
  const {
    components: { emptyReviewsSection }
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
