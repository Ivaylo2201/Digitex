import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useFormatProduct } from '../hooks/useFormatProduct';
import { useProduct } from '../hooks/useProduct';
import { useProductParams } from '../hooks/useProductParams';
import type { Ram } from '../models/Ram';
import { ProductPage } from './ProductPage';

export function RamProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<Ram>(category, id);
  const translation = useTranslation();
  const formatProduct = useFormatProduct(translation);

  return (
    <ProductPage
      product={product}
      category={category}
      specs={formatProduct.toRam(product)}
    />
  );
}
