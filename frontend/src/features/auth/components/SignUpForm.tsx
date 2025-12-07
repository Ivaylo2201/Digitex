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
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useState } from 'react';
import { toast } from 'sonner';
import { useForm } from 'react-hook-form';
import { useSignUp } from '../hooks/sign-up/useSignUp';
import { Spinner } from '@/components/ui/spinner';
import { Link } from 'react-router';
import { Checkbox } from '@/components/ui/checkbox';
import {
  useSignUpSchema,
  type SignUpSchema,
} from '../hooks/sign-up/useSignUpSchema';

export function SignUpForm() {
  const [areTermsAndConditionsAccepted, setAreTermsAndConditionsAccepted] =
    useState<boolean>(false);
  const signUpSchema = useSignUpSchema();

  const { handleSubmit, register } = useForm<SignUpSchema>();
  const { mutate, isPending } = useSignUp();
  const {
    components: { signUpForm },
  } = useTranslation();

  const onSubmit = (data: SignUpSchema) => {
    const result = signUpSchema.safeParse(data);

    if (!result.success) {
      toast.error(result.error?.errors[0].message);
      return;
    }

    mutate(data);
  };

  const handleAcceptTermsAndConditionsToggle = () => {
    setAreTermsAndConditionsAccepted(
      (termsAndConditionsAccepted) => !termsAndConditionsAccepted
    );
  };

  return (
    <Card className='w-full max-w-sm bg-theme-gunmetal text-theme-white'>
      <CardHeader>
        <CardTitle>{signUpForm.createdAnAccount}</CardTitle>
        <CardDescription className='text-gray-400'>
          {signUpForm.enterYourCredentialsToSignUpForAnAccount}
        </CardDescription>
      </CardHeader>

      <CardContent>
        <form onSubmit={handleSubmit(onSubmit)} className='flex flex-col gap-6'>
          <div className='grid gap-2'>
            <Label htmlFor='email'>{signUpForm.email}</Label>
            <Input
              id='email'
              type='text'
              placeholder='email@example.com'
              className='bg-theme-white text-theme-gunmetal placeholder:text-theme-gunmetal'
              {...register('email')}
            />
          </div>

          <div className='grid gap-2'>
            <Label htmlFor='username'>{signUpForm.username}</Label>
            <Input
              id='username'
              type='text'
              className='bg-theme-white text-theme-gunmetal'
              {...register('username')}
            />
          </div>

          <div className='grid gap-2'>
            <Label htmlFor='password'>{signUpForm.password}</Label>
            <Input
              id='password'
              type='password'
              className='bg-theme-white text-theme-gunmetal placeholder:text-theme-gunmetal'
              {...register('password')}
            />
          </div>

          <div className='grid gap-2'>
            <Label htmlFor='passwordConfirmation'>
              {signUpForm.passwordConfirmation}
            </Label>
            <Input
              id='passwordConfirmation'
              type='password'
              className='bg-theme-white text-theme-gunmetal placeholder:text-theme-gunmetal'
              {...register('passwordConfirmation')}
            />
          </div>

          <div className='flex gap-2 items-center'>
            <Checkbox
              id='terms'
              onCheckedChange={handleAcceptTermsAndConditionsToggle}
              className='cursor-pointer data-[state=checked]:bg-theme-crimson'
            />
            <Label htmlFor='terms' className='cursor-pointer'>
              {signUpForm.acceptTermsAndConditions}
            </Label>
          </div>

          <Button
            type='submit'
            disabled={isPending || !areTermsAndConditionsAccepted}
            className='w-full bg-theme-crimson hover:bg-theme-lightcrimson cursor-pointer duration-200 transition-colors'
          >
            {isPending && <Spinner />}
            {signUpForm.signUp}
          </Button>
        </form>
      </CardContent>

      <div className='flex justify-center items-center gap-2'>
        <p className='text-sm text-gray-400'>
          {signUpForm.alreadyHaveAnAccount}
        </p>
        <Link
          to='/auth/sign-in'
          className='text-theme-white text-sm hover:text-theme-crimson duration-200 transition-colors'
        >
          {signUpForm.signIn}
        </Link>
      </div>
    </Card>
  );
}
