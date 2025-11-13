import useProduct from '@/lib/hooks/useProduct';
import type { Processor } from '@/lib/models/products/Processor';
import { useProductParams } from '@/lib/hooks/useProductParams';
import { useTranslation } from '@/lib/stores/useTranslation';
import ProductPage from '../ProductPage';

export default function ProcessorProductPage() {
  const { category, id } = useProductParams();
  const { data: product } = useProduct<Processor>(category, id);
  const translation = useTranslation();

  const specs = [
    {
      spec: translation.specs.processors.cores,
      value: product.cores
    },
    {
      spec: translation.specs.processors.threads,
      value: product.threads
    },
    {
      spec: translation.specs.processors.baseClockSpeed,
      value: `${product.clockSpeed.base} MHz`
    },
    {
      spec: translation.specs.processors.boostClockSpeed,
      value: `${product.clockSpeed.boost} MHz`
    },
    {
      spec: translation.specs.processors.socket,
      value: product.socket.toUpperCase()
    },
    {
      spec: translation.specs.processors.tdp,
      value: `${product.tdp} W`
    }
  ];

  return <ProductPage product={product} category={category} specs={specs} />;
}
