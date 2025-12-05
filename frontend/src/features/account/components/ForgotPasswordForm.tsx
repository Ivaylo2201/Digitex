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
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { toast } from 'sonner';
import { Spinner } from '@/components/ui/spinner';
import {
  useForgotPasswordSchema,
  type ForgotPasswordSchema,
} from '../hooks/forgot-password/useForgotPasswordSchema';
import { useForgotPassword } from '../hooks/forgot-password/useForgotPassword';

export function ForgotPasswordForm() {
  const { handleSubmit, register } = useForm<ForgotPasswordSchema>();
  const forgotPasswordSchema = useForgotPasswordSchema();
  const { mutate, isPending } = useForgotPassword();
  const {
    components: { forgotPasswordForm },
  } = useTranslation();

  const onSubmit = (data: ForgotPasswordSchema) => {
    const result = forgotPasswordSchema.safeParse(data);

    if (!result.success) {
      toast.error(result.error?.errors[0].message);
      return;
    }

    mutate(data);
  };

  return (
    <Card className='w-full max-w-sm bg-theme-gunmetal text-theme-white'>
      <CardHeader>
        <CardTitle>{forgotPasswordForm.resetPassword}</CardTitle>
        <CardDescription className='text-gray-400'>
          {forgotPasswordForm.enterYourEmailToReceiveAPasswordResetEmail}
        </CardDescription>
      </CardHeader>

      <CardContent>
        <form onSubmit={handleSubmit(onSubmit)} className='flex flex-col gap-6'>
          <div className='grid gap-2'>
            <Label htmlFor='email'>{forgotPasswordForm.email}</Label>
            <Input
              id='email'
              type='text'
              placeholder='email@example.com'
              className='bg-theme-white text-theme-gunmetal placeholder:text-theme-gunmetal'
              {...register('email')}
            />
          </div>

          <Button
            type='submit'
            disabled={isPending}
            className='w-full bg-theme-crimson cursor-pointer'
          >
            {isPending && <Spinner />}
            {forgotPasswordForm.sendResetEmail}
          </Button>
        </form>
      </CardContent>
    </Card>
  );
}
