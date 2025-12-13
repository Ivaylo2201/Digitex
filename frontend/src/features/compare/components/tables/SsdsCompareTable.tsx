import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { ProductCompareTable } from './ProductCompareTable';
import { Fragment } from 'react';
import { TableCell, TableHead } from '@/components/ui/table';

type SsdsCompareTableProps = { products: ProductLong[] };

export function SsdsCompareTable({ products }: SsdsCompareTableProps) {
  const {
    specifications: { ssds }
  } = useTranslation();
  const formatProduct = useFormatProduct();

  return (
    <ProductCompareTable
      products={products}
      category='ssds'
      childTableHeads={
        <Fragment>
          <TableHead>{ssds.capacityInGb}</TableHead>
          <TableHead>{ssds.interface}</TableHead>
          <TableHead>{ssds.operationSpeedRead}</TableHead>
          <TableHead>{ssds.operationSpeedWrite}</TableHead>
        </Fragment>
      }
      renderChildTableCells={(product) => (
        <Fragment>
          {formatProduct.toSsd(product).map(({ value }) => (
            <TableCell>{value}</TableCell>
          ))}
        </Fragment>
      )}
    />
  );
}
