import { httpClient } from '@/lib/api/httpClient';
import { useEffect, useState } from 'react';
import { loadStripe, type Stripe } from '@stripe/stripe-js';
import { Elements } from '@stripe/react-stripe-js';
import { CheckoutForm } from './CheckoutForm';
import type { Billing } from '../pages/BillingPage';

type PaymentProps = { billing: Billing; shippingCost: number };

export function Payment({ billing, shippingCost }: PaymentProps) {
  const [stripePromise, setStripePromise] =
    useState<Promise<Stripe | null> | null>(null);
  const [clientSecret, setClientSecret] = useState<string>('');

  useEffect(() => {
    async function init() {
      const { data: keyData } = await httpClient.get<{
        publishableKey: string;
      }>('/stripe/publishable-key');

      setStripePromise(loadStripe(keyData.publishableKey));

      console.log(billing);

      const { data: intentData } = await httpClient.post<{
        clientSecret: string;
      }>('/stripe/create-payment-intent', billing);

      setClientSecret(intentData.clientSecret);
    }

    init();
  }, []);

  if (!stripePromise || !clientSecret) return null;

  return (
    <Elements stripe={stripePromise} options={{ clientSecret }}>
      <CheckoutForm shippingCost={shippingCost} />
    </Elements>
  );
}
