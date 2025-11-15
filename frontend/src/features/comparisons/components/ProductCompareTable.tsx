import {
  TableHeader,
  TableRow,
  TableHead,
  TableBody,
  TableCell,
  Table,
  TableCaption
} from '@/components/ui/table';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { getStaticFile } from '@/lib/utils/getStaticFile';

type ProductCompareTableProps = {
  products: ProductLong[];
  childTableHeads?: React.ReactNode;
  childTableCells: (product: ProductLong) => React.ReactNode;
};

export default function ProductCompareTable({
  products,
  childTableHeads,
  childTableCells
}: ProductCompareTableProps) {
  const translation = useTranslation();

  return (
    <Table className='font-montserrat border'>
      <TableCaption>{translation.keywords.comparedProducts}</TableCaption>
      <TableHeader>
        <TableRow className='bg-theme-gunmetal  [&>th]:text-white pointer-events-none'>
          <TableHead>{translation.specs.product.brand}</TableHead>
          <TableHead>{translation.specs.product.model}</TableHead>
          <TableHead>{translation.specs.product.image}</TableHead>
          <TableHead>{translation.specs.product.price}</TableHead>
          {childTableHeads}
        </TableRow>
      </TableHeader>
      <TableBody>
        {products.map((product, idx) => (
          <TableRow key={idx}>
            <TableCell>{product.brandName}</TableCell>
            <TableCell>{product.modelName}</TableCell>
            <TableCell>
              <img
                src={getStaticFile(product.imagePath)}
                className='h-10 w-auto'
              />
            </TableCell>
            <TableCell>${product.price.discounted.toFixed(2)}</TableCell>
            {childTableCells(product)}
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
}
