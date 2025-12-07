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
  useRequestPasswordResetSchema,
  type RequestPasswordResetSchema,
} from '../hooks/request-password-reset/useRequestPasswordResetSchema';
import { useRequestPasswordReset } from '../hooks/request-password-reset/useRequestPasswordReset';

export function RequestPasswordResetForm() {
  const { handleSubmit, register } = useForm<RequestPasswordResetSchema>();
  const requestPasswordResetSchema = useRequestPasswordResetSchema();
  const { mutate, isPending } = useRequestPasswordReset();
  const {
    components: { requestPasswordResetForm },
  } = useTranslation();

  const onSubmit = (data: RequestPasswordResetSchema) => {
    const result = requestPasswordResetSchema.safeParse(data);

    if (!result.success) {
      toast.error(result.error?.errors[0].message);
      return;
    }

    mutate(data);
  };

  return (
    <Card className='w-full max-w-sm bg-theme-gunmetal text-theme-white'>
      <CardHeader>
        <CardTitle>{requestPasswordResetForm.requestAPasswordReset}</CardTitle>
        <CardDescription className='text-gray-400'>
          {requestPasswordResetForm.enterYourEmailToRequestAPasswordResetForYourAccount}
        </CardDescription>
      </CardHeader>

      <CardContent>
        <form onSubmit={handleSubmit(onSubmit)} className='flex flex-col gap-6'>
          <div className='grid gap-2'>
            <Label htmlFor='email'>{requestPasswordResetForm.email}</Label>
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
            className='w-full bg-theme-crimson hover:bg-theme-lightcrimson cursor-pointer duration-200 transition-colors'
          >
            {isPending && <Spinner />}
            {requestPasswordResetForm.requestAPasswordReset}
          </Button>
        </form>
      </CardContent>
    </Card>
  );
}
