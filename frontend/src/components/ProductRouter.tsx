import { useProductParams } from '@/lib/hooks/useProductParams';
import { Navigate } from 'react-router';
import MonitorProductPage from './pages/products/MonitorProductPage';
import ProcessorProductPage from './pages/products/ProcessorProductPage';

const componentMap: Record<string, React.ComponentType> = {
  processors: ProcessorProductPage,
  monitors: MonitorProductPage
};

export default function ProductRouter() {
  const { category } = useProductParams();

  if (!(category in componentMap)) {
    return <Navigate to='/404' />;
  }

  const Component = componentMap[category];
  return <Component />;
}
