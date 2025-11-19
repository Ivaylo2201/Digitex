import {
  TableHeader,
  TableRow,
  TableHead,
  TableBody,
  TableCell,
  Table,
  TableCaption
} from '@/components/ui/table';

import type { ProductLong } from '@/features/products/models/base/ProductLong';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import { useNavigate } from 'react-router';
import { useCompare } from '../../stores/useCompare';
import { useCurrencyExchange } from '@/features/currency/hooks/useCurrencyExchange';
import { toast } from 'sonner';
import {
  HoverCard,
  HoverCardContent,
  HoverCardTrigger
} from '@/components/ui/hover-card';

type ProductCompareTableProps = {
  products: ProductLong[];
  category: string;
  childTableHeads: React.ReactNode;
  childTableCells: (product: ProductLong) => React.ReactNode;
};

export function ProductCompareTable({
  products,
  category,
  childTableHeads,
  childTableCells
}: ProductCompareTableProps) {
  const translation = useTranslation();
  const navigate = useNavigate();
  const { exchangeCurrency } = useCurrencyExchange();
  const { removeFromCompare } = useCompare();

  const handleRemoveFromCompare = (
    e: React.MouseEvent<HTMLButtonElement, MouseEvent>,
    id: string
  ) => {
    e.stopPropagation();
    removeFromCompare(id);
    toast.success(translation.compare.removeFromCompare);
  };

  return (
    <Table className='font-montserrat border'>
      <TableCaption>{translation.compare.comparedProducts}</TableCaption>
      <TableHeader>
        <TableRow className='[&>th]:text-white bg-theme-gunmetal pointer-events-none'>
          <TableHead>{translation.specs.product.brand}</TableHead>
          <TableHead>{translation.specs.product.model}</TableHead>
          <TableHead>{translation.specs.product.price}</TableHead>
          {childTableHeads}
        </TableRow>
      </TableHeader>
      <TableBody>
        {products.map((product, index) => (
          <HoverCard>
            <HoverCardTrigger asChild>
              <TableRow
                key={index}
                onClick={() => navigate(`/products/${category}/${product.id}`)}
                className={`cursor-pointer hover:bg-theme-crimson hover:text-theme-white duration-300 transform-color ${
                  index % 2 === 0 ? 'bg-gray-100' : ''
                }`}
              >
                <TableCell>{product.brandName}</TableCell>
                <TableCell>{product.modelName}</TableCell>
                <TableCell>
                  {exchangeCurrency(product.price.discounted)}
                </TableCell>
                {childTableCells(product)}
                {/* <TableCell>
                  <Button
                    className='w-5 h-6 p-0 bg-theme-gunmetal hover:bg-gray-400 rounded-full flex items-center justify-center cursor-pointer'
                    onClick={(e) => handleRemoveFromCompare(e, product.id)}
                  >
                    <X />
                  </Button>
                </TableCell> */}
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
