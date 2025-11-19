import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { ProductCompareTable } from './ProductCompareTable';
import { TableHead, TableCell } from '@/components/ui/table';
import React from 'react';

type PowerSuppliesCompareTableProps = {
  products: ProductLong[];
};

export default function PowerSuppliesCompareTable({
  products
}: PowerSuppliesCompareTableProps) {
  const translation = useTranslation();
  const formatProduct = useFormatProduct(translation);

  return (
    <ProductCompareTable
      products={products}
      category='power-supplies'
      childTableHeads={
        <React.Fragment>
          <TableHead>{translation.specs.powerSupplies.formFactor}</TableHead>
          <TableHead>
            {translation.specs.powerSupplies.efficiencyPercentage}
          </TableHead>
          <TableHead>
            {translation.specs.powerSupplies.modularity['spec']}
          </TableHead>
          <TableHead>{translation.specs.powerSupplies.wattage}</TableHead>
        </React.Fragment>
      }
      childTableCells={(product) => (
        <React.Fragment>
          {formatProduct.toPowerSupply(product).map(({ value }) => (
            <TableCell>{value}</TableCell>
          ))}
        </React.Fragment>
      )}
    />
  );
}
