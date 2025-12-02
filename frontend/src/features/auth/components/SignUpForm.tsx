import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useState } from 'react';
import { toast } from 'sonner';
import { signUpSchema, type SignUpSchema } from '../schemas/signUpSchema';
import { useForm } from 'react-hook-form';
import { useSignUp } from '../hooks/useSignUp';

export function SignUpForm() {
  const [isVerificationCardVisible, setIsVerificationCardVisible] = useState<boolean>();
  const { handleSubmit, register, setValue } = useForm<SignUpSchema>();
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

    mutate(data, {
      onSuccess: () => {
        setIsVerificationCardVisible(true);
      },
    });
  };

  return <></>;
}
