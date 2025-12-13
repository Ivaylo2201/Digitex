import {
  TableHeader,
  TableRow,
  TableHead,
  TableBody,
  TableCell,
  Table,
  TableCaption
} from '@/components/ui/table';

import {
  HoverCard,
  HoverCardContent,
  HoverCardTrigger
} from '@/components/ui/hover-card';

import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import { useNavigate } from 'react-router';

type ProductCompareTableProps = {
  products: ProductLong[];
  category: string;
  childTableHeads: React.ReactNode;
  renderChildTableCells: (product: ProductLong) => React.ReactNode;
};

export function ProductCompareTable({
  products,
  category,
  childTableHeads,
  renderChildTableCells
}: ProductCompareTableProps) {
  const {
    specifications: { base },
    components: { productCompareTable }
  } = useTranslation();
  const navigate = useNavigate();
  //const { clearCompare } = useCompare();

  return (
    <Table className='font-montserrat border'>
      <TableCaption>{productCompareTable.comparedProducts}</TableCaption>
      <TableHeader>
        <TableRow className='[&>th]:text-white bg-theme-gunmetal pointer-events-none'>
          <TableHead>{base.brand}</TableHead>
          <TableHead>{base.model}</TableHead>
          <TableHead>{base.price}</TableHead>
          {childTableHeads}
        </TableRow>
      </TableHeader>
      <TableBody>
        {products.map((product, index) => (
          <HoverCard>
            <HoverCardTrigger asChild>
              <TableRow
                key={product.id}
                onClick={() => navigate(`/products/${category}/${product.id}`)}
                className={`cursor-pointer hover:bg-theme-crimson hover:text-theme-white duration-300 transform-color ${
                  index % 2 === 0 ? 'bg-gray-100' : ''
                }`}
              >
                <TableCell>{product.brandName}</TableCell>
                <TableCell>{product.modelName}</TableCell>
                <TableCell>
                  {product.price.discounted}
                </TableCell>
                {renderChildTableCells(product)}
              </TableRow>
            </HoverCardTrigger>
            <HoverCardContent>
              <img src={getStaticFile(product.imagePath)} />
            </HoverCardContent>
          </HoverCard>
        ))}
      </TableBody>
    </Table>
  );
}
