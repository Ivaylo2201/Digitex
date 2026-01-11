import { Page } from '@/components/layout/Page';
import { BillingForm } from '../components/BillingForm';
import { Payment } from '../components/Payment';

export function CheckoutPage() {
  return (
    <Page>
      <div className='flex flex-col lg:flex-row gap-8 lg:gap-20'>
        <BillingForm />
        <Payment />
      </div>
    </Page>
  );
}
