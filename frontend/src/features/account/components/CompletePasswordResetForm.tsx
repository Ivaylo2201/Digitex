import {
  Card,
  CardHeader,
  CardTitle,
  CardDescription,
  CardContent,
} from '@/components/ui/card';

import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';
import { useForm } from 'react-hook-form';
import { useSearchParams } from 'react-router';
import { Spinner } from '@/components/ui/spinner';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { toast } from 'sonner';
import {
  useCompletePasswordResetSchema,
  type CompletePasswordResetSchema,
} from '../hooks/complete-password-reset/useCompletePasswordResetSchema';
import { useCompletePasswordReset } from '../hooks/complete-password-reset/useCompletePasswordReset';

export function CompletePasswordResetForm() {
  const { handleSubmit, register } = useForm<CompletePasswordResetSchema>();
  const [searchParams] = useSearchParams();
  const completePasswordResetSchema = useCompletePasswordResetSchema();
  const { mutate, isPending } = useCompletePasswordReset();
  const {
    components: { completePasswordResetForm },
  } = useTranslation();

  const onSubmit = (data: CompletePasswordResetSchema) => {
    const result = completePasswordResetSchema.safeParse(data);

    if (!result.success) {
      toast.error(result.error?.errors[0].message);
      return;
    }

    const token = searchParams.get('token');

    if (token) {
      mutate({ newPassword: data.newPassword, token });
    }
  };

  return (
    <Card className='w-full max-w-sm bg-theme-gunmetal text-theme-white'>
      <CardHeader>
        <CardTitle>{completePasswordResetForm.completePasswordReset}</CardTitle>
        <CardDescription className='text-gray-400'>
          {completePasswordResetForm.enterYourNewPasswordBelow}
        </CardDescription>
      </CardHeader>

      <CardContent>
        <form onSubmit={handleSubmit(onSubmit)} className='flex flex-col gap-6'>
          <div className='grid gap-2'>
            <Label htmlFor='newPassword'>{completePasswordResetForm.newPassword}</Label>
            <Input
              id='newPassword'
              type='password'
              className='bg-theme-white text-theme-gunmetal'
              {...register('newPassword')}
            />
          </div>

          <div className='grid gap-2'>
            <Label htmlFor='confirm'>
              {completePasswordResetForm.newPasswordConfirmation}
            </Label>
            <Input
              id='newPasswordConfirmation'
              type='password'
              className='bg-theme-white text-theme-gunmetal'
              {...register('newPasswordConfirmation')}
            />
          </div>

          <Button
            type='submit'
            disabled={isPending}
            className='w-full bg-theme-crimson hover:bg-theme-lightcrimson cursor-pointer duration-200 transition-colors'
          >
            {isPending && <Spinner />}
            {completePasswordResetForm.completePasswordReset}
          </Button>
        </form>
      </CardContent>
    </Card>
  );
}
