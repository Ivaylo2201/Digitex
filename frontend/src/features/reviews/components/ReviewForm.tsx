import { useForm } from 'react-hook-form';
import {
  useCreateReviewSchema,
  type CreateReviewSchema,
} from '../hooks/create-review/useCreateReviewSchema';
import { useCreateReview } from '../hooks/create-review/useCreateReview';
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
import { Send } from 'lucide-react';

type ReviewFormProps = {
  productId: string;
};

export function ReviewForm({ productId }: ReviewFormProps) {
  const {
    register,
    handleSubmit,
    watch,
    setValue,
    reset,
    formState: { isSubmitting },
  } = useForm<CreateReviewSchema>({
    defaultValues: { productId, rating: 0, comment: '' },
  });
  const createReviewSchema = useCreateReviewSchema();
  const { mutate, isPending } = useCreateReview();
  const {
    components: { reviewForm },
  } = useTranslation();

  const rating = watch('rating');

  const onSubmit = (data: CreateReviewSchema) => {
    const result = createReviewSchema.safeParse(data);

    if (!result.success) {
      toast.error(result.error?.errors[0].message);
      return;
    }

    mutate(data);
    reset();
  };

  return (
    <Card className='w-full max-w-md bg-theme-gunmetal text-theme-white self-center mt-8'>
      <CardHeader>
        <CardTitle>{reviewForm.leaveAReview}</CardTitle>
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
              placeholder={reviewForm.leaveAComment}
              className='bg-theme-white text-theme-gunmetal placeholder:text-theme-gunmetal'
              {...register('comment')}
            />
          </div>

          <Button
            type='submit'
            disabled={isSubmitting}
            className='w-full bg-theme-crimson hover:bg-theme-lightcrimson cursor-pointer duration-200 transition-colors flex items-center justify-center gap-2'
          >
            {isPending && <Spinner />}
            <Send />
            {reviewForm.submitReview}
          </Button>
        </form>
      </CardContent>
    </Card>
  );
}
