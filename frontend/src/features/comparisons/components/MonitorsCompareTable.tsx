import { TableHead, TableCell } from '@/components/ui/table';

import type { ProductLong } from '@/features/products/models/base/ProductLong';
import type { Monitor } from '@/features/products/models/Monitor';
import ProductCompareTable from './ProductCompareTable';
import React from 'react';

type MonitorsCompareTableProps = { products: ProductLong[] };

export default function MonitorsCompareTable({
  products
}: MonitorsCompareTableProps) {
  return (
    <ProductCompareTable
      products={products}
      childTableHeads={
        <>
          <TableHead>Diagonal</TableHead>
          <TableHead>Refresh Rate</TableHead>
          <TableHead>Latency</TableHead>
          <TableHead>Matrix</TableHead>
          <TableHead>Resolution</TableHead>
          <TableHead>Pixel Size</TableHead>
          <TableHead>Brightness</TableHead>
          <TableHead>Color Spectrum</TableHead>
        </>
      }
      childTableCells={(product) => {
        const monitor = product as Monitor;
        return (
          <React.Fragment>
            <TableCell>{monitor.displayDiagonal}"</TableCell>
            <TableCell>{monitor.refreshRate} Hz</TableCell>
            <TableCell>{monitor.latency} ms</TableCell>
            <TableCell>{monitor.matrix}</TableCell>
            <TableCell>
              {monitor.resolution.width} x {monitor.resolution.height}{' '}
              {monitor.resolution.type}
            </TableCell>
            <TableCell>{monitor.pixelSize} µm</TableCell>
            <TableCell>{monitor.brightness} cd/m²</TableCell>
            <TableCell>{monitor.colorSpectre}%</TableCell>
          </React.Fragment>
        );
      }}
    />
  );
}
