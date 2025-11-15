import { TableHead, TableCell } from '@/components/ui/table';

import type { ProductLong } from '@/features/products/models/base/ProductLong';
import type { Monitor } from '@/features/products/models/Monitor';
import ProductCompareTable from './ProductCompareTable';
import React from 'react';
import { formatMonitor } from '@/lib/utils/productFormatters';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';

type MonitorsCompareTableProps = { products: ProductLong[] };

export default function MonitorsCompareTable({
  products
}: MonitorsCompareTableProps) {
  const translation = useTranslation();

  return (
    <ProductCompareTable
      products={products}
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
      childTableCells={(product) => {
        const monitor = formatMonitor(product as Monitor, translation);
        return (
          <React.Fragment>
            {monitor.map((m) => (
              <TableCell>{m.value}</TableCell>
            ))}
          </React.Fragment>
        );
      }}
    />
  );
}
