import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import { useProduct } from '@/features/products/hooks/useProduct';
import { useProductParams } from '@/features/products/hooks/useProductParams';
import type { GraphicsCard } from '@/features/products/models/GraphicsCard';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { ProductPage } from '../ProductPage';

export function GraphicsCardsProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<GraphicsCard>(category, id);
  const translation = useTranslation();
  const formatProduct = useFormatProduct(translation);

  return (
    <ProductPage
      product={product}
      category={category}
      specs={formatProduct.toGraphicsCard(product)}
    />
  );
}
