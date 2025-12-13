import { useTranslation } from '@/features/language/hooks/useTranslation';
import type { Review } from '../models/Review';
import { Separator } from '@/components/ui/separator';
import { ScrollArea } from '@/components/ui/scroll-area';
import { Rating } from '@/features/products/components/Rating';
import { EmptyReviewsSection } from './EmptyReviewsSection';

type ReviewsSectionProps = {
  reviews: Review[];
};

export function ReviewsSection({ reviews }: ReviewsSectionProps) {
  const {
    components: { reviewsSection },
  } = useTranslation();
  const hasReviews = reviews.length > 0;

  return (
    <section className='flex flex-col'>
      <p className='text-xl font-semibold text-theme-gunmetal'>
        {reviewsSection.reviews}
      </p>
      <Separator
        orientation='horizontal'
        className='bg-gray-300 h-px mt-2 mb-4'
      />
      {hasReviews ? (
        <ScrollArea className='h-72'>
          <div className='flex md:grid md:grid-cols-2 md:items-center flex-col gap-4'>
            {reviews.map((review) => (
              <article key={review.id} className='p-1 flex flex-col gap-2'>
                <div className='flex flex-col'>
                  <p className='font-medium'>{review.username}</p>
                  <Rating stars={4} starSize={13} />
                </div>
                <p className='max-w-110 text-gray-500 text-sm'>
                  {review.comment ?? 'No comment provided.'}
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
