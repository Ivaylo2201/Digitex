import { ScrollArea } from '@/components/ui/scroll-area';
import { Separator } from '@/components/ui/separator';
import type { Review } from '@/features/reviews/models/Review';
import { type Translation } from '@/lib/i18n/models/Translation';
import {
  Empty,
  EmptyHeader,
  EmptyMedia,
  EmptyTitle,
  EmptyDescription
} from '@/components/ui/empty';
import { MessageSquareX } from 'lucide-react';
import { Rating } from '@/features/products/components/Rating';

type ReviewsProps = {
  reviews: Review[];
  translation: Translation;
};

export function Reviews({ reviews, translation }: ReviewsProps) {
  const hasReviews = reviews.length > -1;

  return (
    <section className='flex flex-col'>
      <p className='text-xl font-semibold text-theme-gunmetal'>
        {translation.keywords.reviews}
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
        <EmptyReviews />
      )}
    </section>
  );
}

function EmptyReviews() {
  return (
    <Empty>
      <EmptyHeader>
        <EmptyMedia variant='icon'>
          <MessageSquareX />
        </EmptyMedia>
        <EmptyTitle>No reviews for this product</EmptyTitle>
        <EmptyDescription>
          <p>No reviews have been left for this product yet.</p>
          <p className='flex justify-center items-center gap-1.5'>
            Write the first review via the form below.
          </p>
        </EmptyDescription>
      </EmptyHeader>
    </Empty>
  );
}
