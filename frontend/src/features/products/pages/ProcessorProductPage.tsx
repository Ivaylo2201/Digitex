import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import useProduct from '../hooks/useProduct';
import { useProductParams } from '../hooks/useProductParams';
import type { Processor } from '../models/Processor';
import ProductPage from './ProductPage';
import { useFormatProduct } from '../hooks/useFormatProduct';

export default function ProcessorProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<Processor>(category, id);
  const translation = useTranslation();
  const formatProduct = useFormatProduct(translation);

  return (
    <ProductPage
      product={product}
      category={category}
      specs={formatProduct.toProcessor(product)}
    />
  );
}
