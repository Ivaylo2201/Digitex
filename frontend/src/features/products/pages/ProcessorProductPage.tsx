import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import useProduct from '../hooks/useProduct';
import { useProductParams } from '../hooks/useProductParams';
import type { Processor } from '../models/Processor';
import ProductPage from './ProductPage';
import { formatProcessor } from '@/lib/utils/productFormatters';

export default function ProcessorProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<Processor>(category, id);
  const translation = useTranslation();

  return (
    <ProductPage
      product={product}
      category={category}
      specs={formatProcessor(product, translation)}
    />
  );
}
