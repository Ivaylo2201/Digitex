import { TableHead, TableCell } from '@/components/ui/table';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import ProductCompareTable from './ProductCompareTable';
import React from 'react';
import { formatProcessor } from '@/lib/utils/productFormatters';
import type { Processor } from '@/features/products/models/Processor';

type ProcessorCompareTableProps = { products: ProductLong[] };

export default function ProcessorCompareTable({
  products
}: ProcessorCompareTableProps) {
  const translation = useTranslation();

  return (
    <ProductCompareTable
      products={products}
      category='processors'
      childTableHeads={
        <React.Fragment>
          <TableHead>{translation.specs.processors.cores}</TableHead>
          <TableHead>{translation.specs.processors.threads}</TableHead>
          <TableHead>{translation.specs.processors.baseClockSpeed}</TableHead>
          <TableHead>{translation.specs.processors.boostClockSpeed}</TableHead>
          <TableHead>{translation.specs.processors.socket}</TableHead>
          <TableHead>{translation.specs.processors.tdp}</TableHead>
        </React.Fragment>
      }
      childTableCells={(product) => {
        return (
          <React.Fragment>
            {formatProcessor(product as Processor, translation).map(
              (processor, idx) => (
                <TableCell key={idx}>{processor.value}</TableCell>
              )
            )}
          </React.Fragment>
        );
      }}
    />
  );
}
