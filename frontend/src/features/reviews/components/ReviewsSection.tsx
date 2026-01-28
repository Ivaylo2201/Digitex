import { useTranslation } from '@/features/language/hooks/useTranslation';
import { Separator } from '@/components/ui/separator';
import { Rating } from '@/features/products/components/Rating';
import { EmptyReviewsSection } from './EmptyReviewsSection';
import { ReviewForm } from './ReviewForm';
import { useReviews } from '../hooks/useReviews';

type ReviewsSectionProps = {
  productId: string;
};

export function ReviewsSection({ productId }: ReviewsSectionProps) {
  const {
    components: { reviewsSection },
  } = useTranslation();

  const { data: reviews } = useReviews(productId);
  const hasReviews = (reviews?.length ?? 0) > 0;

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
        <div className='grid gap-4 grid-cols-1 lg:grid-cols-2'>
          {reviews?.map((review) => (
            <article
              key={review.id}
              className='p-4 flex flex-col gap-2 bg-theme-gunmetal rounded-lg shadow-sm'
            >
              <div className='flex flex-col gap-1'>
                <div className='flex justify-between items-center'>
                  <p className='font-medium text-white'>{review.username}</p>
                  <span className='text-gray-400 text-xs'>
                    {new Date(review.createdAt).toLocaleDateString(undefined, {
                      year: 'numeric',
                      month: 'short',
                      day: 'numeric',
                    })}
                  </span>
                </div>
                <Rating stars={review.rating} starSize={14} />
              </div>
              <div className='text-gray-300 text-sm mt-1'>
                <p className={review.comment === '' ? 'italic' : ''}>
                  {review.comment === ''
                    ? reviewsSection.noCommentProvided
                    : review.comment}
                </p>
              </div>
            </article>
          ))}
        </div>
      ) : (
        <EmptyReviewsSection />
      )}
      <ReviewForm productId={productId} />
    </section>
  );
}
