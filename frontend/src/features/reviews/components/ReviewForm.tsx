import { useForm } from 'react-hook-form';
import {
  useWriteReviewSchema,
  type WriteReviewSchema,
} from '../hooks/write-review/useWriteReviewSchema';
import { useWriteReview } from '../hooks/write-review/useWriteReview';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { toast } from 'sonner';
import { Button } from '@/components/ui/button';
import {
  Card,
  CardHeader,
  CardTitle,
  CardDescription,
  CardContent,
} from '@/components/ui/card';
import { Rating } from '@/features/products/components/Rating';
import { Label } from '@/components/ui/label';
import { Textarea } from '@/components/ui/textarea';
import { Spinner } from '@/components/ui/spinner';

type ReviewFormProps = {
  productId: string;
};

export function ReviewForm({ productId }: ReviewFormProps) {
  const {
    register,
    handleSubmit,
    watch,
    setValue,
    formState: { isSubmitting },
  } = useForm<WriteReviewSchema>({
    defaultValues: { productId, rating: 0, comment: '' },
  });
  const writeReviewSchema = useWriteReviewSchema();
  const { mutate, isPending } = useWriteReview();
  const {
    components: { reviewForm },
  } = useTranslation();

  const rating = watch('rating');

  const onSubmit = (data: WriteReviewSchema) => {
    const result = writeReviewSchema.safeParse(data);
    console.log(data);

    if (!result.success) {
      toast.error(result.error?.errors[0].message);
      return;
    }

    mutate(data);
  };

  return (
    <Card className='w-full max-w-md bg-theme-gunmetal text-theme-white self-center'>
      <CardHeader>
        <CardTitle>{reviewForm.writeAReview}</CardTitle>
        <CardDescription className='text-gray-400'>
          {reviewForm.shareYourThoughtsAndRatingForThisProduct}
        </CardDescription>
      </CardHeader>

      <CardContent>
        <form onSubmit={handleSubmit(onSubmit)} className='flex flex-col gap-6'>
          <div className='grid gap-2'>
            <Label>{reviewForm.rating}</Label>
            <div className='flex gap-1'>
              <Rating
                onStarClick={(starIndex) => setValue('rating', starIndex)}
                stars={rating}
                starSize={24}
              />
            </div>
          </div>

          <div className='grid gap-2'>
            <Label htmlFor='comment'>{reviewForm.comment}</Label>
            <Textarea
              maxLength={500}
              id='comment'
              value={watch('comment')}
              placeholder={reviewForm.writeYourReview}
              className='bg-theme-white text-theme-gunmetal placeholder:text-theme-gunmetal'
              {...register('comment')}
            />
          </div>

          <Button
            type='submit'
            disabled={isSubmitting}
            className='w-full bg-theme-crimson hover:bg-theme-lightcrimson cursor-pointer duration-200 transition-colors'
          >
            {isPending && <Spinner />}
            {reviewForm.submitReview}
          </Button>
        </form>
      </CardContent>
    </Card>
  );
}
