import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import { useProduct } from '@/features/products/hooks/useProduct';
import { useProductParams } from '@/features/products/hooks/useProductParams';
import type { GraphicsCard } from '@/features/products/models/GraphicsCard';
import { ProductPage } from '../ProductPage';

export function GraphicsCardsProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<GraphicsCard>(category, id);
  const formatProduct = useFormatProduct();

  return (
    <ProductPage
      product={product}
      category={category}
      onFormatSpecifications={formatProduct.toGraphicsCard}
    />
  );
}
