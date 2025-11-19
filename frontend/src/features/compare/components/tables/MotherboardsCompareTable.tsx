import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { ProductCompareTable } from './ProductCompareTable';
import React from 'react';
import { TableCell, TableHead } from '@/components/ui/table';

type MotherboardsCompareTableProps = {
  products: ProductLong[];
};

export default function MotherboardsCompareTable({
  products
}: MotherboardsCompareTableProps) {
  const translation = useTranslation();
  const formatProduct = useFormatProduct(translation);

  return (
    <ProductCompareTable
      products={products}
      category='motherboards'
      childTableHeads={
        <React.Fragment>
          <TableHead>{translation.specs.motherboards.socket}</TableHead>
          <TableHead>{translation.specs.motherboards.formFactor}</TableHead>
          <TableHead>{translation.specs.motherboards.chipset}</TableHead>
          <TableHead>{translation.specs.motherboards.ramSlots}</TableHead>
          <TableHead>{translation.specs.motherboards.pcieSlots}</TableHead>
        </React.Fragment>
      }
      childTableCells={(product) => (
        <React.Fragment>
          {formatProduct.toMotherboard(product).map(({ value }) => (
            <TableCell>{value}</TableCell>
          ))}
        </React.Fragment>
      )}
    />
  );
}
