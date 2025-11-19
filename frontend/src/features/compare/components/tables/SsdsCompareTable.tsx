import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { ProductCompareTable } from './ProductCompareTable';
import React from 'react';
import { TableCell, TableHead } from '@/components/ui/table';

type SsdsCompareTableProps = { products: ProductLong[] };

export function SsdsCompareTable({ products }: SsdsCompareTableProps) {
  const translation = useTranslation();
  const formatProduct = useFormatProduct(translation);

  return (
    <ProductCompareTable
      products={products}
      category='ssds'
      childTableHeads={
        <React.Fragment>
          <TableHead>{translation.specs.ssds.capacityInGb}</TableHead>
          <TableHead>{translation.specs.ssds.interface}</TableHead>
          <TableHead>{translation.specs.ssds.operationSpeedRead}</TableHead>
          <TableHead>{translation.specs.ssds.operationSpeedWrite}</TableHead>
        </React.Fragment>
      }
      childTableCells={(product) => (
        <React.Fragment>
          {formatProduct.toSsd(product).map(({ value }) => (
            <TableCell>{value}</TableCell>
          ))}
        </React.Fragment>
      )}
    />
  );
}
