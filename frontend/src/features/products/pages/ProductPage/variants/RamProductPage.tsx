import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import { useProduct } from '@/features/products/hooks/useProduct';
import { useProductParams } from '@/features/products/hooks/useProductParams';
import type { Ram } from '@/features/products/models/Ram';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { ProductPage } from '../ProductPage';

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
