import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableRow
} from '@/components/ui/table';
import type { ProductLong } from '@/lib/models/products/ProductLong';
import { useTranslation } from '@/lib/stores/useTranslation';
import Page from './Page';
import ProductPageBreadcrumb from '../shared/ProductPageBreadcrumb';

type ProductPageProps<T extends ProductLong> = {
  category: string;
  product: T;
  specs: { spec: string; value: string | number }[];
};

export default function ProductPage<T extends ProductLong>({
  category,
  product,
  specs
}: ProductPageProps<T>) {
  const translation = useTranslation();

  return (
    <Page>
      <ProductPageBreadcrumb category={category} product={product} />
      <Table className='w-1/2 font-montserrat border border-gray-200'>
        <TableCaption>{translation.keywords.mainSpecifications}</TableCaption>
        <TableBody className='text-theme-gunmetal'>
          {specs.map((item, index) => (
            <TableRow
              className={`pointer-events-none ${
                index % 2 !== 1 ? 'bg-theme-gunmetal text-theme-white' : ''
              }`}
              key={index}
            >
              <TableCell className='w-1/2'>{item.spec}</TableCell>
              <TableCell className='w-1/2 font-medium'>{item.value}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </Page>
  );
}
