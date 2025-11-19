import { TableHead, TableCell } from '@/components/ui/table';

import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { ProductCompareTable } from './ProductCompareTable';
import React from 'react';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';

type MonitorsCompareTableProps = { products: ProductLong[] };

export function MonitorsCompareTable({ products }: MonitorsCompareTableProps) {
  const translation = useTranslation();
  const formatProduct = useFormatProduct(translation);

  return (
    <ProductCompareTable
      products={products}
      category='monitors'
      childTableHeads={
        <React.Fragment>
          <TableHead>{translation.specs.monitors.displayDiagonal}</TableHead>
          <TableHead>{translation.specs.monitors.refreshRate}</TableHead>
          <TableHead>{translation.specs.monitors.latency}</TableHead>
          <TableHead>{translation.specs.monitors.matrix}</TableHead>
          <TableHead>{translation.specs.monitors.resolution}</TableHead>
          <TableHead>{translation.specs.monitors.pixelSize}</TableHead>
          <TableHead>{translation.specs.monitors.brightness}</TableHead>
          <TableHead>{translation.specs.monitors.colorSpectre}</TableHead>
        </React.Fragment>
      }
      childTableCells={(product) => (
        <React.Fragment>
          {formatProduct.toMonitor(product).map(({ value }) => (
            <TableCell>{value}</TableCell>
          ))}
        </React.Fragment>
      )}
    />
  );
}
