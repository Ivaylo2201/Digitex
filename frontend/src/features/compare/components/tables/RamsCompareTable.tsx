import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { ProductCompareTable } from './ProductCompareTable';
import { Fragment } from 'react';
import { TableCell, TableHead } from '@/components/ui/table';

type RamsCompareTableProps = { products: ProductLong[] };

export function RamsCompareTable({ products }: RamsCompareTableProps) {
  const {
    specifications: { rams }
  } = useTranslation();
  const formatProduct = useFormatProduct();

  return (
    <ProductCompareTable
      products={products}
      category='rams'
      childTableHeads={
        <Fragment>
          <TableHead>{rams.memory}</TableHead>
          <TableHead>{rams.timing}</TableHead>
        </Fragment>
      }
      renderChildTableCells={(product) => (
        <Fragment>
          {formatProduct.toRam(product).map(({ value }) => (
            <TableCell>{value}</TableCell>
          ))}
        </Fragment>
      )}
    />
  );
}
