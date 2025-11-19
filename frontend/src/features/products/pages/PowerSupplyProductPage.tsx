import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useProduct } from '../hooks/useProduct';
import { useProductParams } from '../hooks/useProductParams';
import type { PowerSupply } from '../models/PowerSupply';
import { useFormatProduct } from '../hooks/useFormatProduct';
import { ProductPage } from './ProductPage';

export function PowerSupplyProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<PowerSupply>(category, id);
  const translation = useTranslation();
  const formatProduct = useFormatProduct(translation);

  return (
    <ProductPage
      product={product}
      category={category}
      specs={formatProduct.toPowerSupply(product)}
    />
  );
}
