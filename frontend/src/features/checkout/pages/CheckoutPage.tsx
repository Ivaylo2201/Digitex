import { Page } from '@/components/layout/Page';
import { Payment } from '../components/Payment';

type CheckoutPageProps = {};

export function CheckoutPage({}: CheckoutPageProps) {
  return <Page><Payment /></Page>;
}
