import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import useProduct from '../hooks/useProduct';
import { useProductParams } from '../hooks/useProductParams';
import type { Monitor } from '../models/Monitor';
import ProductPage from './ProductPage';

export default function MonitorProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<Monitor>(category, id);
  const translation = useTranslation();

  const specs = [
    {
      spec: translation.specs.monitors.displayDiagonal,
      value: `${product.displayDiagonal}"`
    },
    {
      spec: translation.specs.monitors.refreshRate,
      value: `${product.refreshRate} Hz`
    },
    {
      spec: translation.specs.monitors.latency,
      value: `${product.latency} ms`
    },
    {
      spec: translation.specs.monitors.matrix,
      value: product.matrix.toUpperCase()
    },
    {
      spec: translation.specs.monitors.resolution,
      value: `${product.resolution.width}x${product.resolution.height} ${product.resolution.type}`
    },
    {
      spec: translation.specs.monitors.pixelSize,
      value: `${product.pixelSize} mm`
    },
    {
      spec: translation.specs.monitors.brightness,
      value: `${product.brightness} nits`
    },
    {
      spec: translation.specs.monitors.colorSpectre,
      value: `${product.colorSpectre}%`
    }
  ];

  return <ProductPage product={product} category={category} specs={specs} />;
}
