import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useFormatProduct } from '../hooks/useFormatProduct';
import { useProduct } from '../hooks/useProduct';
import { useProductParams } from '../hooks/useProductParams';
import { ProductPage } from './ProductPage';
import type { Ssd } from '../models/Ssd';

export function SsdProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<Ssd>(category, id);
  const translation = useTranslation();
  const formatProduct = useFormatProduct(translation);

  return (
    <ProductPage
      product={product}
      category={category}
      specs={formatProduct.toSsd(product)}
    />
  );
}
