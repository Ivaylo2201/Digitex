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
import { Link } from 'react-router';
import { useForm } from 'react-hook-form';
import { toast } from 'sonner';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { signInSchema, type SignInSchema } from '../schemas/signInSchema';
import { useSignIn } from '../hooks/useSignIn';
import { Checkbox } from '@/components/ui/checkbox';
import { Spinner } from '@/components/ui/spinner';

export function SignInForm() {
  const { handleSubmit, register, setValue } = useForm<SignInSchema>();
  const { mutate, isPending } = useSignIn();
  const {
    components: { signInForm },
  } = useTranslation();

  const onSubmit = (data: SignInSchema) => {
    const result = signInSchema.safeParse(data);

    if (!result.success) {
      toast.error(result.error?.errors[0].message);
      return;
    }

    mutate(data);
  };

  return (
    <Card className='w-full max-w-sm bg-theme-gunmetal text-theme-white'>
      <CardHeader>
        <CardTitle>{signInForm.signInToYourAccount}</CardTitle>
        <CardDescription className='text-gray-400'>
          {signInForm.enterYourCredentialsToSignInToYourAccount}
        </CardDescription>
      </CardHeader>

      <CardContent>
        <form onSubmit={handleSubmit(onSubmit)} className='flex flex-col gap-6'>
          <div className='grid gap-2'>
            <Label htmlFor='email'>{signInForm.email}</Label>
            <Input
              id='email'
              type='email'
              placeholder='email@example.com'
              className='bg-theme-white text-theme-gunmetal placeholder:text-theme-gunmetal'
              {...register('email')}
            />
          </div>

          <div className='grid gap-2'>
            <Label htmlFor='password'>{signInForm.password}</Label>
            <Input
              id='password'
              type='password'
              className='bg-theme-white text-theme-gunmetal placeholder:text-theme-gunmetal'
              {...register('password')}
            />
          </div>

          <div className='flex gap-2 items-center'>
            <Checkbox
              id='terms'
              onCheckedChange={(state) =>
                setValue('rememberMe', state === true)
              }
            />
            <Label htmlFor='terms'>{signInForm.rememberMe}</Label>
          </div>

          <Button
            type='submit'
            disabled={isPending}
            className='w-full bg-theme-crimson cursor-pointer'
          >
            {isPending && <Spinner />}
            {signInForm.signIn}
          </Button>
        </form>
      </CardContent>

      <div className='flex justify-center items-center gap-2'>
        <p className='text-sm text-gray-400'>{signInForm.dontHaveAnAccount}</p>
        <Link
          to='/auth/sign-up'
          className='text-theme-white text-sm hover:text-theme-crimson duration-200 transition-colors'
        >
          {signInForm.signUp}
        </Link>
      </div>
    </Card>
  );
}
