import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import { useProduct } from '@/features/products/hooks/useProduct';
import { useProductParams } from '@/features/products/hooks/useProductParams';
import type { Monitor } from '@/features/products/models/Monitor';
import { ProductPage } from '../ProductPage';

export function MonitorProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<Monitor>(category, id);
  const formatProduct = useFormatProduct();

  return (
    <ProductPage
      product={product}
      category={category}
      onFormatSpecifications={formatProduct.toMonitor}
    />
  );
}
