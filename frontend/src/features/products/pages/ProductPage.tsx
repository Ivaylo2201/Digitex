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
  const displayName = `${product.brandName} ${product.modelName}`;
  const imageSrc = `${import.meta.env.VITE_STATIC_FILES_URL}/${
    product.imagePath
  }`;

  return (
    <Page>
      <section className='flex flex-col gap-4'>
        <ProductPageBreadcrumb category={category} displayName={displayName} />
        <div className='flex flex-col gap-14'>
          <p className='text-5xl text-theme-gunmetal font-bold'>
            {displayName}
          </p>
          <img src={imageSrc} alt={displayName} className='object-contain' />
          <Table className='font-montserrat border border-gray-200'>
            <TableCaption>
              {translation.keywords.mainSpecifications}
            </TableCaption>
            <TableBody className='text-theme-gunmetal'>
              {specs.map((item, index) => (
                <TableRow
                  className={`pointer-events-none ${
                    index % 2 !== 0 ? 'bg-theme-gunmetal text-theme-white' : ''
                  }`}
                  key={index}
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
