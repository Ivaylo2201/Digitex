import { useMostSoldProduct } from '../hooks/useMostSoldProduct';
import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle
} from '@/components/ui/card';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import {
  Empty,
  EmptyHeader,
  EmptyMedia,
  EmptyTitle,
  EmptyDescription,
} from '@/components/ui/empty';
import { X } from 'lucide-react';

export function MostSoldProductCard() {
  const { data: product, isError } = useMostSoldProduct();
  const {
    components: { mostSoldProduct }
  } = useTranslation();

  if (isError) return <EmptyMostSoldProduct />;

  return (
    <Card className='bg-white text-black border border-gray-200 shadow-sm'>
      <CardHeader className='pb-2'>
        <CardTitle className='text-base font-semibold'>
          {mostSoldProduct.mostSoldProduct}
        </CardTitle>
      </CardHeader>

      <CardContent className='p-4 pt-0 flex gap-4 items-center'>
        <img
          src={getStaticFile(product?.imagePath ?? '')}
          alt={product?.modelName}
          className='w-20 h-20 object-contain'
        />

        <div className='flex flex-col'>
          <span className='text-sm text-gray-500'>{product?.brandName}</span>
          <span className='font-medium'>{product?.modelName}</span>
          <span className='text-lg font-bold'>€{product?.price}</span>
        </div>
      </CardContent>

      <CardFooter className='pt-0 text-sm flex flex-col text-gray-500 text-left items-start'>
        <div>
          {mostSoldProduct.sales}: {product?.sales}
        </div>
        <div>
          {mostSoldProduct.quantitySold}: {product?.quantity}
        </div>
      </CardFooter>
    </Card>
  );
}

function EmptyMostSoldProduct() {
  return (
    <Empty>
      <EmptyHeader>
        <EmptyMedia variant='icon'>
          <X />
        </EmptyMedia>
        <EmptyTitle>No sales have been made yet</EmptyTitle>
        <EmptyDescription>
          <p className='flex justify-center items-center gap-1.5'>
            Once a sale occures the product will display here
          </p>
        </EmptyDescription>
      </EmptyHeader>
    </Empty>
  );
}
