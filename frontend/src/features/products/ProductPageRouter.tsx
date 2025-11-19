import { useProductParams } from '@/features/products/hooks/useProductParams';
import { Navigate } from 'react-router';
import { ProcessorProductPage } from './pages/ProcessorProductPage';
import { MonitorProductPage } from './pages/MonitorProductPage';
import { GraphicsCardsProductPage } from './pages/GraphicsCardsProductPage';
import { MotherboardProductPage } from './pages/MotherboardProductPage';
import { RamProductPage } from './pages/RamProductPage';
import { SsdProductPage } from './pages/SsdProductPage';
import { PowerSupplyProductPage } from './pages/PowerSupplyProductPage';

const productPages: Record<string, React.ComponentType> = {
  processors: ProcessorProductPage,
  monitors: MonitorProductPage,
  'graphics-cards': GraphicsCardsProductPage,
  motherboards: MotherboardProductPage,
  rams: RamProductPage,
  ssds: SsdProductPage,
  'power-supplies': PowerSupplyProductPage
};

export function ProductPageRouter() {
  const { category } = useProductParams();

  if (!(category in productPages)) {
    return <Navigate to='/404' />;
  }

  const Component = productPages[category];
  return <Component />;
}
