import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableRow
} from '@/components/ui/table';
import type { ProductLong } from '@/lib/models/products/ProductLong';
import Page from './Page';
import { useTranslation } from '@/lib/stores/useTranslation';

type ProductPageProps = {
  product: ProductLong;
  data: Record<string, string>;
};

export default function ProductPage({
  product,
  data
}: ProductPageProps) {
  const translation = useTranslation();

  return (
    <Page>
      <Table className='w-1/2 font-montserrat border border-gray-200'>
      <TableCaption>{translation.products.mainSpecifications}</TableCaption>
      <TableBody className='text-theme-gunmetal'>
        {Object.entries(data).map(([key, value], idx) => (
          <TableRow
            key={idx}
            className={`${idx % 2 === 0 ? 'bg-gray-300' : ''}`}
          >
            <TableCell className='w-1/2'>{key}</TableCell>
            <TableCell className='w-1/2 font-medium'>{value}</TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
    </Page>
  );
}