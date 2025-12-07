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
import { Checkbox } from '@/components/ui/checkbox';
import { Spinner } from '@/components/ui/spinner';
import { useSignIn } from '../hooks/sign-in/useSignIn';
import {
  useSignInSchema,
  type SignInSchema,
} from '../hooks/sign-in/useSignInSchema';

export function SignInForm() {
  const { handleSubmit, register, setValue } = useForm<SignInSchema>();
  const signInSchema = useSignInSchema();
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
              type='text'
              placeholder='email@example.com'
              className='bg-theme-white text-theme-gunmetal placeholder:text-theme-gunmetal'
              {...register('email')}
            />
          </div>

          <div className='grid gap-2'>
            <div className='flex justify-between items-center'>
              <Label htmlFor='password'>{signInForm.password}</Label>
              <Link
                to='/account/request-password-reset'
                className='text-gray-400 text-sm hover:text-theme-crimson duration-200 transition-colors'
              >
                {signInForm.forgotPassword}
              </Link>
            </div>
            <Input
              id='password'
              type='password'
              className='bg-theme-white text-theme-gunmetal placeholder:text-theme-gunmetal'
              {...register('password')}
            />
          </div>

          <div className='flex gap-2 items-center'>
            <Checkbox
              id='rememberMe'
              onCheckedChange={(state) =>
                setValue('rememberMe', state === true)
              }
              className='cursor-pointer data-[state=checked]:bg-theme-crimson'
            />
            <Label htmlFor='rememberMe' className='cursor-pointer'>
              {signInForm.rememberMe}
            </Label>
          </div>

          <Button
            type='submit'
            disabled={isPending}
            className='w-full bg-theme-crimson hover:bg-theme-lightcrimson cursor-pointer duration-200 transition-colors'
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
