import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableRow
} from '@/components/ui/table';

import type { ProductLong } from '@/features/products/models/base/ProductLong';
import ProductPageBreadcrumb from '../components/ProductCard/ProductPageBreadcrumb';
import Page from '@/components/layout/Page';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import type { Translation } from '@/lib/i18n/models/Translation';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import { toast } from 'sonner';
import { useCompare } from '@/features/compare/stores/useCompare';
import { Button } from '@/components/ui/button';
import { ArrowLeftRight } from 'lucide-react';

type ProductPageProps<T extends ProductLong> = {
  category: string;
  product: T;
  specs: { spec: string; value: string | number }[];
};

export default function ProductPage<T extends ProductLong>({
  category,
  product,
  specs
}: ProductPageProps<T>) {
  const translation = useTranslation();
  const { addToCompare } = useCompare();
  const displayName = `${product.brandName} ${product.modelName}`;

  const handleAddToCompare = (
    product: ProductLong & { category: string },
    translation: Translation
  ) => {
    const addToCompareResult = addToCompare(product, translation);

    if (addToCompareResult.isSuccess) {
      toast.success(addToCompareResult.message);
    } else {
      toast.error(addToCompareResult.message);
    }
  };

  return (
    <Page>
      <section className='flex flex-col gap-4 w-full'>
        <ProductPageBreadcrumb category={category} displayName={displayName} />
        <Button
          className='w-10 h-10 p-0 bg-theme-gunmetal rounded-full flex items-center justify-center cursor-pointer'
          onClick={() =>
            handleAddToCompare({ ...product, category }, translation)
          }
        >
          <ArrowLeftRight />
        </Button>

        <div className='flex flex-col gap-14'>
          <p className='text-5xl text-theme-gunmetal font-bold'>
            {displayName}
          </p>
          <img
            src={getStaticFile(product.imagePath)}
            alt={displayName}
            className='object-contain max-w-140'
          />
          <Table className='font-montserrat border border-gray-200'>
            <TableCaption>
              {translation.keywords.mainSpecifications}
            </TableCaption>
            <TableBody className='text-theme-gunmetal'>
              {specs.map((item, idx) => (
                <TableRow
                  className={`pointer-events-none ${
                    idx % 2 !== 0 ? 'bg-theme-gunmetal text-theme-white' : ''
                  }`}
                  key={idx}
                >
                  <TableCell className='w-1/2'>{item.spec}</TableCell>
                  <TableCell className='w-1/2 font-medium'>
                    {item.value}
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </div>
      </section>
    </Page>
  );
}
