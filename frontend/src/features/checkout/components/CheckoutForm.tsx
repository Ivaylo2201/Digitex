import { Button } from '@/components/ui/button';
import { useStripe, useElements } from '@stripe/react-stripe-js';
import { PaymentElement } from '@stripe/react-stripe-js';
import { useState } from 'react';

export function CheckoutForm() {
  const stripe = useStripe();
  const elements = useElements();
  const [isProcessing, setIsProcessing] = useState(false);

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    if (!stripe || !elements) {
      return;
    }

    setIsProcessing(true);

    await stripe.confirmPayment({
      elements,
      confirmParams: {
        return_url: 'http://localhost:5173/',
      },
    });

    setIsProcessing(false);
  };

  return (
    <form
      id='payment-form'
      className='flex flex-col gap-4'
      onSubmit={handleSubmit}
    >
      <PaymentElement className='w-72 md:w-[500px]' id='payment-element' />
      <Button
        disabled={isProcessing}
        className='bg-theme-crimson hover:bg-theme-gunmetal transition-colors duration-300 cursor-pointer'
      >
        Pay now
      </Button>
    </form>
  );
}
