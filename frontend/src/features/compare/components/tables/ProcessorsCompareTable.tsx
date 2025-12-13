import { TableHead, TableCell } from '@/components/ui/table';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { ProductCompareTable } from './ProductCompareTable';
import { Fragment } from 'react';
import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';

type ProcessorCompareTableProps = { products: ProductLong[] };

export function ProcessorCompareTable({
  products
}: ProcessorCompareTableProps) {
  const {
    specifications: { processors }
  } = useTranslation();
  const formatProduct = useFormatProduct();

  return (
    <ProductCompareTable
      products={products}
      category='processors'
      childTableHeads={
        <Fragment>
          <TableHead>{processors.cores}</TableHead>
          <TableHead>{processors.threads}</TableHead>
          <TableHead>{processors.baseClockSpeed}</TableHead>
          <TableHead>{processors.boostClockSpeed}</TableHead>
          <TableHead>{processors.socket}</TableHead>
          <TableHead>{processors.tdp}</TableHead>
        </Fragment>
      }
      renderChildTableCells={(product) => (
        <Fragment>
          {formatProduct.toProcessor(product).map(({ value }) => (
            <TableCell>{value}</TableCell>
          ))}
        </Fragment>
      )}
    />
  );
}
