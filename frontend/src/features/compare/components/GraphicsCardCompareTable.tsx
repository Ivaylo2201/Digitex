import { TableCell, TableHead } from '@/components/ui/table';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import React from 'react';
import ProductCompareTable from './ProductCompareTable';
import type { GraphicsCard } from '@/features/products/models/GraphicsCard';
import { formatGraphicsCard } from '@/lib/utils/productFormatters';

type GraphicsCardCompareTableProps = { products: ProductLong[] };

export default function GraphicsCardCompareTable({
  products
}: GraphicsCardCompareTableProps) {
  const translation = useTranslation();

  return (
    <ProductCompareTable
      products={products}
      category='graphics-cards'
      childTableHeads={
        <React.Fragment>
          <TableHead>{translation.specs.graphicsCards.memory}</TableHead>
          <TableHead>{translation.specs.graphicsCards.baseClockSpeed}</TableHead>
          <TableHead>{translation.specs.graphicsCards.boostClockSpeed}</TableHead>
          <TableHead>{translation.specs.graphicsCards.busWidth}</TableHead>
          <TableHead>{translation.specs.graphicsCards.cudaCores}</TableHead>
          <TableHead>
            {translation.specs.graphicsCards.directXSupport}
          </TableHead>
          <TableHead>{translation.specs.graphicsCards.tdp}</TableHead>
        </React.Fragment>
      }
      childTableCells={(product) => {
        return (
          <React.Fragment>
            {formatGraphicsCard(product as GraphicsCard, translation).map(
              (graphicsCard) => (
                <TableCell>{graphicsCard.value}</TableCell>
              )
            )}
          </React.Fragment>
        );
      }}
    />
  );
}
