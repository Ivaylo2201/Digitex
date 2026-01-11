import { httpClient } from '@/lib/api/httpClient';
import { useEffect, useState } from 'react';
import { loadStripe, type Stripe } from '@stripe/stripe-js';
import { Elements } from '@stripe/react-stripe-js';
import { CheckoutForm } from './CheckoutForm';

export function Payment() {
  const [stripePromise, setStripePromise] =
    useState<Promise<Stripe | null> | null>(null);
  const [clientSecret, setClientSecret] = useState<string>('');

  useEffect(() => {
    httpClient
      .get<{ publishableKey: string }>('/stripe/publishable-key')
      .then((res) => {
        const { publishableKey } = res.data;
        setStripePromise(loadStripe(publishableKey));
      });

    httpClient
      .post<{ clientSecret: string }>('/stripe/create-payment-intent')
      .then((res) => {
        setClientSecret(res.data.clientSecret);
      });
  }, []);

  return (
    <>
      {stripePromise && clientSecret && (
        <Elements stripe={stripePromise} options={{ clientSecret }}>
          <CheckoutForm />
        </Elements>
      )}
    </>
  );
}
