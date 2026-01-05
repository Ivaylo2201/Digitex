import { getStaticFile } from '@/lib/utils/getStaticFile';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';
import { Button } from '@/components/ui/button';
import { TableRow, TableCell } from '@/components/ui/table';
import { Minus, Plus, X } from 'lucide-react';
import type { Item } from '../types/Item';
import { useQuantityControl } from '@/features/products/hooks/useQuantityControl';
import { useRemoveFromCart } from '../hooks/useRemoveFromCart';
import { useUpdateQuantity } from '../hooks/useUpdateQuantity';

type ItemRowProps = {
  item: Item;
};

export function ItemRow({ item }: ItemRowProps) {
  const { quantity, handleQuantityDecrease, handleQuantityIncrease } =
    useQuantityControl(item.quantity, item.product.stockQuantity);
  const { mutate: removeFromCart } = useRemoveFromCart(item.id);
  const { mutate: updateQuantity } = useUpdateQuantity(item.id);
  const sign = useCurrencyStore((state) => state.currency.sign);

  return (
    <TableRow className='h-24'>
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
        <div className='w-20'>
          {sign}
          {item.lineTotal.toFixed(2)}
        </div>
      </TableCell>

      <TableCell>
        <div className='flex w-fit items-center rounded-md border'>
          <Button
            size='icon'
            variant='ghost'
            className='cursor-pointer'
            onClick={() => {
              handleQuantityDecrease();
              updateQuantity({ newQuantity: quantity - 1 });
            }}
          >
            <Minus className='h-4 w-4' />
          </Button>
          <div className='w-10 text-center text-sm'>{quantity}</div>
          <Button
            size='icon'
            variant='ghost'
            className='cursor-pointer'
            onClick={() => {
              handleQuantityIncrease();
              updateQuantity({ newQuantity: quantity + 1 });
            }}
          >
            <Plus className='h-4 w-4' />
          </Button>
        </div>
      </TableCell>
      <TableCell>
        <Button
          size='icon'
          variant='ghost'
          className='text-red-500 cursor-pointer'
          onClick={() => removeFromCart()}
        >
          <X className='h-4 w-4' />
        </Button>
      </TableCell>
    </TableRow>
  );
}
