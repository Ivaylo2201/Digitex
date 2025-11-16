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
import { useCompare } from '../stores/useCompare';
import { Button } from '@/components/ui/button';
import { X } from 'lucide-react';
import useCurrencyExchange from '@/features/currency/hooks/useCurrencyExchange';

type ProductCompareTableProps = {
  products: ProductLong[];
  category: string;
  childTableHeads: React.ReactNode;
  childTableCells: (product: ProductLong) => React.ReactNode;
};

export default function ProductCompareTable({
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
  };

  return (
    <Table className='font-montserrat border'>
      <TableCaption>{translation.keywords.comparedProducts}</TableCaption>
      <TableHeader>
        <TableRow className='bg-theme-gunmetal [&>th]:text-white pointer-events-none'>
          <TableHead>{translation.specs.product.brand}</TableHead>
          <TableHead>{translation.specs.product.model}</TableHead>
          <TableHead>{translation.specs.product.image}</TableHead>
          <TableHead>{translation.specs.product.price}</TableHead>
          {childTableHeads}
          <TableHead></TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        {products.map((product, idx) => (
          <TableRow
            key={idx}
            onClick={() => navigate(`/products/${category}/${product.id}`)}
            className='cursor-pointer hover:bg-gray-100 [&>td]:border [&>td]:min-w-30'
          >
            <TableCell>{product.brandName}</TableCell>
            <TableCell>{product.modelName}</TableCell>
            <TableCell>
              <img
                src={getStaticFile(product.imagePath)}
                className='h-11 w-full object-contain'
              />
            </TableCell>
            <TableCell>{exchangeCurrency(product.price.discounted)}</TableCell>
            {childTableCells(product)}
            <TableCell className='px-5'>
              <Button
                className='w-5 h-6 p-0 bg-theme-gunmetal hover:bg-gray-400 rounded-full flex items-center justify-center cursor-pointer'
                onClick={(e) => handleRemoveFromCompare(e, product.id)}
              >
                <X />
              </Button>
            </TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
}
