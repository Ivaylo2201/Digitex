import { Page } from '@/components/layout/Page';
import { useCart } from '../hooks/useCart';
import { Loader } from '@/features/products/components/Loader';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';
import {
  TableHeader,
  TableRow,
  TableHead,
  TableBody,
  Table,
} from '@/components/ui/table';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { Separator } from '@/components/ui/separator';
import { Link } from 'react-router';
import { ItemRow } from '../components/ItemRow';
import { EmptyComparePage } from '@/features/compare/pages/EmptyComparePage';
import { EmptyCartPage } from './EmptyCartPage';

export function CartPage() {
  const { data: cart } = useCart();
  const sign = useCurrencyStore((state) => state.currency.sign);
  const {
    components: { cartPage },
  } = useTranslation();

  if (!cart) {
    return (
      <Page>
        <Loader />
      </Page>
    );
  }

  if (cart.items.length === 0) {
    return <EmptyCartPage />;
  }

  return (
    <Page>
      <div className='flex flex-col gap-5'>
        <div className='rounded-xl border bg-white flex'>
          <Table>
            <TableHeader className='[&_th]:font-bold [&_th]:bg-theme-gunmetal [&_th]:text-theme-white'>
              <TableRow className='h-12'>
                <TableHead className='pl-5 rounded-tl-xl'>
                  {cartPage.product}
                </TableHead>
                <TableHead className='px-8'>{cartPage.price}</TableHead>
                <TableHead>{cartPage.quantity}</TableHead>
                <TableHead className='rounded-tr-xl' />
              </TableRow>
            </TableHeader>

            <TableBody>
              {cart.items.map((item) => (
                <ItemRow key={item.id} item={item} />
              ))}
            </TableBody>
          </Table>
        </div>

        <section>
          <Separator className='mt-2 mb-6' />
          <section className='flex justify-between items-center'>
            <p className='font-medium'>{cartPage.subtotal}</p>
            <div className='flex justify-center items-center gap-5'>
              <p className='font-medium'>
                {sign}
                {cart.totalPrice.toFixed(2)}
              </p>
              <Link
                to='/checkout'
                className='rounded-full text-white px-3 py-2 text-sm bg-theme-crimson hover:bg-theme-lightcrimson cursor-pointer transition-colors duration-200'
              >
                {cartPage.proceedToCheckout}
              </Link>
            </div>
          </section>
        </section>
      </div>
    </Page>
  );
}
