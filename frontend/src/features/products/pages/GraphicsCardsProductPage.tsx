import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import useProduct from '../hooks/useProduct';
import { useProductParams } from '../hooks/useProductParams';
import ProductPage from './ProductPage';
import type { GraphicsCard } from '../models/GraphicsCard';
import { useFormatProduct } from '../hooks/useFormatProduct';

export default function GraphicsCardsProductPage() {
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
