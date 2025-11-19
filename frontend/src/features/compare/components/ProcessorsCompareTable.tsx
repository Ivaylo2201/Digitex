import { TableHead, TableCell } from "@/components/ui/table";
import type { ProductLong } from "@/features/products/models/base/ProductLong";
import { useTranslation } from "@/lib/i18n/hooks/useTranslation";
import ProductCompareTable from "./ProductCompareTable";
import React from "react";
import { useFormatProduct } from "@/features/products/hooks/useFormatProduct";

type ProcessorCompareTableProps = { products: ProductLong[] };

export default function ProcessorCompareTable({
  products,
}: ProcessorCompareTableProps) {
  const translation = useTranslation();
  const formatProduct = useFormatProduct(translation);

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
      childTableCells={(product) => (
        <React.Fragment>
          {formatProduct.toProcessor(product).map(({ value }) => (
            <TableCell>{value}</TableCell>
          ))}
        </React.Fragment>
      )}
    />
  );
}
