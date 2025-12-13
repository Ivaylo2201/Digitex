import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import { useProduct } from '@/features/products/hooks/useProduct';
import { useProductParams } from '@/features/products/hooks/useProductParams';
import type { Ssd } from '@/features/products/models/Ssd';
import { ProductPage } from '../ProductPage';

export function SsdProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<Ssd>(category, id);
  const formatProduct = useFormatProduct();

  return (
    <ProductPage
      product={product}
      category={category}
      onFormatSpecifications={formatProduct.toSsd}
    />
  );
}
