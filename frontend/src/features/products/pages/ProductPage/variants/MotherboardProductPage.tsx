import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import { useProduct } from '@/features/products/hooks/useProduct';
import { useProductParams } from '@/features/products/hooks/useProductParams';
import type { Motherboard } from '@/features/products/models/Motherboard';
import { ProductPage } from '../ProductPage';

export function MotherboardProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<Motherboard>(category, id);
  const formatProduct = useFormatProduct();

  return (
    <ProductPage
      product={product}
      category={category}
      onFormatSpecifications={formatProduct.toMotherboard}
    />
  );
}
