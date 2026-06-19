import { Button } from '@/components/ui/button';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { useStripe, useElements } from '@stripe/react-stripe-js';
import { PaymentElement } from '@stripe/react-stripe-js';
import { useState } from 'react';
import { useCart } from '@/features/cart/hooks/useCart';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';
import { useNavigate } from 'react-router';
import { useQueryClient } from '@tanstack/react-query';

type CheckoutFormProps = { shippingCost: number };

export function CheckoutForm({ shippingCost }: CheckoutFormProps) {
  const { data } = useCart();
  const stripe = useStripe();
  const elements = useElements();
  const { currency } = useCurrencyStore();
  const navigate = useNavigate();
  const queryClient = useQueryClient();

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

    const { paymentIntent } = await stripe.confirmPayment({
      elements,
      redirect: 'if_required',
    });

    setIsProcessing(false);

    if (paymentIntent?.status === 'succeeded') {
      setTimeout(async () => {
        await queryClient.invalidateQueries({
          queryKey: ['cart', currency.currencyIsoCode],
        });
      }, 1000);
      await queryClient.invalidateQueries({ queryKey: ['orders'] });
      navigate(`/thank-you?payment_intent=${paymentIntent.id}`);
    }
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
        {checkoutForm.pay} {currency.sign}
        {((data?.totalPrice ?? 0) + shippingCost).toFixed(2)} {checkoutForm.now}
      </Button>
    </form>
  );
}
