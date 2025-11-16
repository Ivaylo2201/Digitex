import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { formatGraphicsCard } from '@/lib/utils/productFormatters';
import useProduct from '../hooks/useProduct';
import { useProductParams } from '../hooks/useProductParams';
import ProductPage from './ProductPage';
import type { GraphicsCard } from '../models/GraphicsCard';

export default function GraphicsCardsProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<GraphicsCard>(category, id);
  const translation = useTranslation();

  return (
    <ProductPage
      product={product}
      category={category}
      specs={formatGraphicsCard(product, translation)}
    />
  );
}
