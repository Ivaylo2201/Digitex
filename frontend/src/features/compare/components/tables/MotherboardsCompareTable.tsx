import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { ProductCompareTable } from './ProductCompareTable';
import { Fragment } from 'react';
import { TableCell, TableHead } from '@/components/ui/table';

type MotherboardsCompareTableProps = {
  products: ProductLong[];
};

export default function MotherboardsCompareTable({
  products
}: MotherboardsCompareTableProps) {
  const {
    specifications: { motherboards }
  } = useTranslation();
  const formatProduct = useFormatProduct();

  return (
    <ProductCompareTable
      products={products}
      category='motherboards'
      childTableHeads={
        <Fragment>
          <TableHead>{motherboards.socket}</TableHead>
          <TableHead>{motherboards.formFactor}</TableHead>
          <TableHead>{motherboards.chipset}</TableHead>
          <TableHead>{motherboards.ramSlots}</TableHead>
          <TableHead>{motherboards.pcieSlots}</TableHead>
        </Fragment>
      }
      childTableCells={(product) => (
        <Fragment>
          {formatProduct.toMotherboard(product).map(({ value }) => (
            <TableCell>{value}</TableCell>
          ))}
        </Fragment>
      )}
    />
  );
}
