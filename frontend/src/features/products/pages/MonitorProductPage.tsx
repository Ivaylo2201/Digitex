import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import useProduct from '../hooks/useProduct';
import { useProductParams } from '../hooks/useProductParams';
import type { Monitor } from '../models/Monitor';
import ProductPage from './ProductPage';
import { formatMonitor } from '@/lib/utils/productFormatters';

export default function MonitorProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<Monitor>(category, id);
  const translation = useTranslation();

  return (
    <ProductPage
      product={product}
      category={category}
      specs={formatMonitor(product, translation)}
    />
  );
}
