import { TableCell, TableHead } from '@/components/ui/table';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { Fragment } from 'react';
import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import { ProductCompareTable } from './ProductCompareTable';

type GraphicsCardsCompareTableProps = { products: ProductLong[] };

export function GraphicsCardsCompareTable({
  products
}: GraphicsCardsCompareTableProps) {
  const {
    specifications: { graphicsCards }
  } = useTranslation();
  const formatProduct = useFormatProduct();

  return (
    <ProductCompareTable
      products={products}
      category='graphics-cards'
      childTableHeads={
        <Fragment>
          <TableHead>{graphicsCards.memory}</TableHead>
          <TableHead>{graphicsCards.baseClockSpeed}</TableHead>
          <TableHead>{graphicsCards.boostClockSpeed}</TableHead>
          <TableHead>{graphicsCards.busWidth}</TableHead>
          <TableHead>{graphicsCards.cudaCores}</TableHead>
          <TableHead>{graphicsCards.directXSupport}</TableHead>
          <TableHead>{graphicsCards.tdp}</TableHead>
        </Fragment>
      }
      renderChildTableCells={(product) => (
        <Fragment>
          {formatProduct.toGraphicsCard(product).map(({ value }) => (
            <TableCell>{value}</TableCell>
          ))}
        </Fragment>
      )}
    />
  );
}
