import { Button } from '@/components/ui/button';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { useStripe, useElements } from '@stripe/react-stripe-js';
import { PaymentElement } from '@stripe/react-stripe-js';
import { useState } from 'react';
import { useCart } from '@/features/cart/hooks/useCart';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';

type CheckoutFormProps = { shippingCost: number };

export function CheckoutForm({ shippingCost }: CheckoutFormProps) {
  const { data } = useCart();
  const stripe = useStripe();
  const elements = useElements();
  const sign = useCurrencyStore((store) => store.currency.sign);

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

  console.log(data?.totalPrice, shippingCost);

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
        {((data?.totalPrice ?? 0) + shippingCost).toFixed(2)} {checkoutForm.now}
      </Button>
    </form>
  );
}
