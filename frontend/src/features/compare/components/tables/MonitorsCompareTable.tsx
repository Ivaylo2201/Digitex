import { TableHead, TableCell } from '@/components/ui/table';

import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { ProductCompareTable } from './ProductCompareTable';
import { Fragment } from 'react';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';

type MonitorsCompareTableProps = { products: ProductLong[] };

export function MonitorsCompareTable({ products }: MonitorsCompareTableProps) {
  const {
    specifications: { monitors }
  } = useTranslation();
  const formatProduct = useFormatProduct();

  return (
    <ProductCompareTable
      products={products}
      category='monitors'
      childTableHeads={
        <Fragment>
          <TableHead>{monitors.displayDiagonal}</TableHead>
          <TableHead>{monitors.refreshRate}</TableHead>
          <TableHead>{monitors.latency}</TableHead>
          <TableHead>{monitors.matrix}</TableHead>
          <TableHead>{monitors.resolution}</TableHead>
          <TableHead>{monitors.pixelSize}</TableHead>
          <TableHead>{monitors.brightness}</TableHead>
          <TableHead>{monitors.colorSpectre}</TableHead>
        </Fragment>
      }
      childTableCells={(product) => (
        <Fragment>
          {formatProduct.toMonitor(product).map(({ value }) => (
            <TableCell>{value}</TableCell>
          ))}
        </Fragment>
      )}
    />
  );
}
