import { Page } from '@/components/layout/Page';
import { BillingForm } from '../components/BillingForm';
import { Payment } from '../components/Payment';
import { useState } from 'react';

export function CheckoutPage() {
  const [shipmentId, setShipmentId] = useState<number>(1);

  return (
    <Page>
      <div className='flex flex-col lg:flex-row gap-8 lg:gap-20'>
        <BillingForm shipmentId={shipmentId} setShipmentId={setShipmentId} />
        <Payment shipmentId={shipmentId} />
      </div>
    </Page>
  );
}
