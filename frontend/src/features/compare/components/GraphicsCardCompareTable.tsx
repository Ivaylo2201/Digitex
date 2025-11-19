import { TableCell, TableHead } from '@/components/ui/table';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import React from 'react';
import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import { ProductCompareTable } from './ProductCompareTable';

type GraphicsCardCompareTableProps = { products: ProductLong[] };

export function GraphicsCardCompareTable({
  products,
}: GraphicsCardCompareTableProps) {
  const translation = useTranslation();
  const formatProduct = useFormatProduct(translation);

  return (
    <ProductCompareTable
      products={products}
      category='graphics-cards'
      childTableHeads={
        <React.Fragment>
          <TableHead>{translation.specs.graphicsCards.memory}</TableHead>
          <TableHead>
            {translation.specs.graphicsCards.baseClockSpeed}
          </TableHead>
          <TableHead>
            {translation.specs.graphicsCards.boostClockSpeed}
          </TableHead>
          <TableHead>{translation.specs.graphicsCards.busWidth}</TableHead>
          <TableHead>{translation.specs.graphicsCards.cudaCores}</TableHead>
          <TableHead>
            {translation.specs.graphicsCards.directXSupport}
          </TableHead>
          <TableHead>{translation.specs.graphicsCards.tdp}</TableHead>
        </React.Fragment>
      }
      childTableCells={(product) => (
        <React.Fragment>
          {formatProduct.toGraphicsCard(product).map(({ value }) => (
            <TableCell>{value}</TableCell>
          ))}
        </React.Fragment>
      )}
    />
  );
}
