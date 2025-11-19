import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { ProductCompareTable } from './ProductCompareTable';
import React from 'react';
import { TableCell, TableHead } from '@/components/ui/table';

type RamsCompareTableProps = { products: ProductLong[] };

export function RamsCompareTable({ products }: RamsCompareTableProps) {
  const translation = useTranslation();
  const formatProduct = useFormatProduct(translation);

  return (
    <ProductCompareTable
      products={products}
      category='rams'
      childTableHeads={
        <React.Fragment>
          <TableHead>{translation.specs.rams.memory}</TableHead>
          <TableHead>{translation.specs.rams.timing}</TableHead>
        </React.Fragment>
      }
      childTableCells={(product) => (
        <React.Fragment>
          {formatProduct.toRam(product).map(({ value }) => (
            <TableCell>{value}</TableCell>
          ))}
        </React.Fragment>
      )}
    />
  );
}
