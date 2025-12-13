import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import { useProduct } from '@/features/products/hooks/useProduct';
import { useProductParams } from '@/features/products/hooks/useProductParams';
import type { Ram } from '@/features/products/models/Ram';
import { ProductPage } from '../ProductPage';

export function RamProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<Ram>(category, id);
  const formatProduct = useFormatProduct();

  return (
    <ProductPage
      product={product}
      category={category}
      onFormatSpecifications={formatProduct.toRam}
    />
  );
}
