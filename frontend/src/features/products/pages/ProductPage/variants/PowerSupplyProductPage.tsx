import { useFormatProduct } from '@/features/products/hooks/useFormatProduct';
import { useProduct } from '@/features/products/hooks/useProduct';
import { useProductParams } from '@/features/products/hooks/useProductParams';
import type { PowerSupply } from '@/features/products/models/PowerSupply';
import { ProductPage } from '../ProductPage';

export function PowerSupplyProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<PowerSupply>(category, id);
  const formatProduct = useFormatProduct();

  return (
    <ProductPage
      product={product}
      category={category}
      onFormatSpecifications={formatProduct.toPowerSupply}
    />
  );
}
