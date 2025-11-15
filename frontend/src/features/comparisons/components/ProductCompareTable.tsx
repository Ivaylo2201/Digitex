import {
  TableHeader,
  TableRow,
  TableHead,
  TableBody,
  TableCell,
  Table
} from '@/components/ui/table';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { getStaticFile } from '@/lib/utils/getStaticFile';

type ProductCompareTableProps = {
  products: ProductLong[];
  childTableHeads?: React.ReactNode;
  childTableCells?: (product: ProductLong) => React.ReactNode;
};

export default function ProductCompareTable({
  products,
  childTableHeads,
  childTableCells
}: ProductCompareTableProps) {
  return (
    <Table className='font-montserrat text-theme-gunmetal'>
      <TableHeader>
        <TableRow>
          <TableHead>Brand</TableHead>
          <TableHead>Model</TableHead>
          <TableHead>Image</TableHead>
          <TableHead>Price</TableHead>
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
            {childTableCells && childTableCells(product)}
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
}
