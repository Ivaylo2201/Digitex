import { Page } from '@/components/layout/Page';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import { useCart } from '../hooks/useCart';
import { Loader } from '@/features/products/components/Loader';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';
import { Button } from '@/components/ui/button';
import {
  TableHeader,
  TableRow,
  TableHead,
  TableBody,
  TableCell,
  Table,
} from '@/components/ui/table';
import { Minus, Plus, X } from 'lucide-react';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { Separator } from '@/components/ui/separator';
import { Link } from 'react-router';

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
                <TableRow key={item.id} className='h-24'>
                  <TableCell>
                    <div className='flex items-center gap-4'>
                      <img
                        src={getStaticFile(item.product.imagePath)}
                        alt={item.product.modelName}
                        className='size-16 rounded-md object-contain mr-2 ml-4'
                      />
                      <div>
                        <div className='font-medium w-10 sm:w-50 md:w-80 lg:w-96 truncate'>
                          {item.product.modelName}
                        </div>
                        <div className='text-sm text-muted-foreground'>
                          {item.product.brandName}
                        </div>
                      </div>
                    </div>
                  </TableCell>

                  <TableCell className='font-medium px-8'>
                    {sign}
                    {item.lineTotal.toFixed(2)}
                  </TableCell>

                  <TableCell>
                    <div className='flex w-fit items-center rounded-md border'>
                      <Button size='icon' variant='ghost'>
                        <Minus className='h-4 w-4' />
                      </Button>
                      <div className='w-10 text-center text-sm'>
                        {item.quantity}
                      </div>
                      <Button size='icon' variant='ghost'>
                        <Plus className='h-4 w-4' />
                      </Button>
                    </div>
                  </TableCell>
                  <TableCell>
                    <Button
                      size='icon'
                      variant='ghost'
                      className='text-red-500'
                    >
                      <X className='h-4 w-4' />
                    </Button>
                  </TableCell>
                </TableRow>
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
