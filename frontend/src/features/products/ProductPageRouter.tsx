import { useProductParams } from '@/features/products/hooks/useProductParams';
import { Navigate } from 'react-router';
import ProcessorProductPage from './pages/ProcessorProductPage';
import MonitorProductPage from './pages/MonitorProductPage';

const productPages: Record<string, React.ComponentType> = {
  processors: ProcessorProductPage,
  monitors: MonitorProductPage
};

export default function ProductPageRouter() {
  const { category } = useProductParams();

  if (!(category in productPages)) {
    return <Navigate to='/404' />;
  }

  const Component = productPages[category];
  return <Component />;
}
