import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { ProductCompareTable } from './ProductCompareTable';
import { TableHead, TableCell } from '@/components/ui/table';
import { Fragment } from 'react';

type PowerSuppliesCompareTableProps = {
  products: ProductLong[];
};

export default function PowerSuppliesCompareTable({
  products,
}: PowerSuppliesCompareTableProps) {
  const {
    specifications: { powerSupplies },
  } = useTranslation();
  const formatProduct = useFormatProduct();

  return (
    <ProductCompareTable
      products={products}
      category='power-supplies'
      childTableHeads={
        <Fragment>
          <TableHead>{powerSupplies.formFactor}</TableHead>
          <TableHead>{powerSupplies.efficiencyPercentage}</TableHead>
          <TableHead>{powerSupplies.modularity.label}</TableHead>
          <TableHead>{powerSupplies.wattage}</TableHead>
        </Fragment>
      }
      renderChildTableCells={(product) => (
        <Fragment>
          {formatProduct.toPowerSupply(product).map(({ value }) => (
            <TableCell>{value}</TableCell>
          ))}
        </Fragment>
      )}
    />
  );
}
