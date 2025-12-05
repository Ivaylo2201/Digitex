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
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { toast } from 'sonner';
import {
  useResetPasswordSchema,
  type ResetPasswordSchema,
} from '../hooks/reset-password/useResetPasswordSchema';
import { useResetPassword } from '../hooks/reset-password/useResetPassword';

export function ResetPasswordForm() {
  const { handleSubmit, register } = useForm<ResetPasswordSchema>();
  const [searchParams] = useSearchParams();
  const resetPasswordSchema = useResetPasswordSchema();
  const { mutate, isPending } = useResetPassword();
  const {
    components: { resetPasswordForm },
  } = useTranslation();

  const onSubmit = (data: ResetPasswordSchema) => {
    const result = resetPasswordSchema.safeParse(data);

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
        <CardTitle>{resetPasswordForm.resetYourPassword}</CardTitle>
        <CardDescription className='text-gray-400'>
          {resetPasswordForm.enterYourNewPasswordBelow}
        </CardDescription>
      </CardHeader>

      <CardContent>
        <form onSubmit={handleSubmit(onSubmit)} className='flex flex-col gap-6'>
          <div className='grid gap-2'>
            <Label htmlFor='newPassword'>{resetPasswordForm.newPassword}</Label>
            <Input
              id='newPassword'
              type='password'
              className='bg-theme-white text-theme-gunmetal'
              {...register('newPassword')}
            />
          </div>

          <div className='grid gap-2'>
            <Label htmlFor='confirm'>
              {resetPasswordForm.newPasswordConfirmation}
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
            className='w-full bg-theme-crimson cursor-pointer'
          >
            {isPending && <Spinner />}
            {resetPasswordForm.resetPassword}
          </Button>
        </form>
      </CardContent>
    </Card>
  );
}
