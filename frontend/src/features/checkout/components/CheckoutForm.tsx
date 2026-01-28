import { Button } from '@/components/ui/button';
import { useCart } from '@/features/cart/hooks/useCart';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { useStripe, useElements } from '@stripe/react-stripe-js';
import { PaymentElement } from '@stripe/react-stripe-js';
import { useState } from 'react';

export function CheckoutForm() {
  const stripe = useStripe();
  const elements = useElements();
  const sign = useCurrencyStore((store) => store.currency.sign);
  const { data: cart } = useCart();
  const {
    components: { checkoutForm },
  } = useTranslation();
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
        return_url: 'http://localhost:5173/thank-you',
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
        {checkoutForm.pay} {sign}
        {cart?.totalPrice.toFixed(2)} {checkoutForm.now}
      </Button>
    </form>
  );
}
