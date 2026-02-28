import { httpClient } from '@/lib/api/httpClient';
import { useEffect, useState } from 'react';
import { loadStripe, type Stripe } from '@stripe/stripe-js';
import { Elements } from '@stripe/react-stripe-js';
import { CheckoutForm } from './CheckoutForm';

type PaymentProps = { shipmentId: number };

export function Payment({ shipmentId }: PaymentProps) {
  const [stripePromise, setStripePromise] =
    useState<Promise<Stripe | null> | null>(null);
  const [clientSecret, setClientSecret] = useState<string>('');

  useEffect(() => {
    async function init() {
      const { data: keyData } = await httpClient.get<{
        publishableKey: string;
      }>('/stripe/publishable-key');

      setStripePromise(loadStripe(keyData.publishableKey));

      console.log(shipmentId);

      const { data: intentData } = await httpClient.post<{
        clientSecret: string;
      }>('/stripe/create-payment-intent', { shipmentId });

      setClientSecret(intentData.clientSecret);
    }

    init();
  }, []);

  if (!stripePromise || !clientSecret) return null;

  return (
    <Elements stripe={stripePromise} options={{ clientSecret }}>
      <CheckoutForm />
    </Elements>
  );
}
