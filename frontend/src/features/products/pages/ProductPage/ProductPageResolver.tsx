import { useProductParams } from '@/features/products/hooks/useProductParams';
import { Navigate } from 'react-router';
import { GraphicsCardsProductPage } from './variants/GraphicsCardsProductPage';
import { MonitorProductPage } from './variants/MonitorProductPage';
import { MotherboardProductPage } from './variants/MotherboardProductPage';
import { PowerSupplyProductPage } from './variants/PowerSupplyProductPage';
import { ProcessorProductPage } from './variants/ProcessorProductPage';
import { RamProductPage } from './variants/RamProductPage';
import { SsdProductPage } from './variants/SsdProductPage';

const productPages: Record<string, React.ComponentType> = {
  processors: ProcessorProductPage,
  monitors: MonitorProductPage,
  'graphics-cards': GraphicsCardsProductPage,
  motherboards: MotherboardProductPage,
  rams: RamProductPage,
  ssds: SsdProductPage,
  'power-supplies': PowerSupplyProductPage,
};

export function ProductPageResolver() {
  const { category } = useProductParams();

  if (!(category in productPages)) {
    return <Navigate to='/404' />;
  }

  const Component = productPages[category];
  return <Component />;
}
