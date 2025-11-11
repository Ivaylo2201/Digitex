import useProduct from '@/lib/hooks/useProduct';
import type { Monitor } from '@/lib/models/products/Monitor';
import ProductPage from '../base/ProductPage';
import { useTranslation } from '@/lib/stores/useTranslation';

export default function MonitorsProductPage() {
  const { data: product } = useProduct<Monitor>('monitors');
  const translation = useTranslation();

  const formattedData = {
    [translation.products.monitors.specs.displayDiagonal]: `${product.displayDiagonal}"`,
    [translation.products.monitors.specs.refreshRate]: `${product.refreshRate} Hz`,
    [translation.products.monitors.specs.latency]: `${product.latency}ms`,
    [translation.products.monitors.specs.matrix]: product.matrix.toUpperCase(),
    [translation.products.monitors.specs.resolution]: `${product.resolution.width}x${product.resolution.height}`,
    [translation.products.monitors.specs.pixelSize]: `${product.pixelSize}µm`,
    [translation.products.monitors.specs.brightness]: `${product.brightness} cd/m²`,
    [translation.products.monitors.specs.colorSpectre]: `${product.colorSpectre}%`
  };

  return <ProductPage product={product} data={formattedData} />;
}
