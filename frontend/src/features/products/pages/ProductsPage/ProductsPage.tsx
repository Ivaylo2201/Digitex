import { Navigate, useParams } from 'react-router';
import { Page } from '@/components/layout/Page';
import { useProducts } from '../../hooks/useProducts';
import { Loader } from './components/Loader';
import { ProductsList } from './components/ProductsList';
import { GraphicsCardsFilterForm } from '@/features/filters/components/forms/GraphicsCardsFilterForm';
import { MotherboardsFilterForm } from '@/features/filters/components/forms/MotherboardsFilterForm';
import { ProcessorsFilterForm } from '@/features/filters/components/forms/ProcessorsFilterForm';
import { RamsFilterForm } from '@/features/filters/components/forms/RamFilterForm';
import { MonitorsFilterForm } from '@/features/filters/components/forms/MonitorsFilterForm';
import { SsdsFilterForm } from '@/features/filters/components/forms/SsdsFilterForm';
import { PowerSuppliesFilterForm } from '@/features/filters/components/forms/PowerSuppliesFilterForm';

const filterForms: Record<string, React.ComponentType> = {
  'graphics-cards': GraphicsCardsFilterForm,
  motherboards: MotherboardsFilterForm,
  processors: ProcessorsFilterForm,
  rams: RamsFilterForm,
  monitors: MonitorsFilterForm,
  ssds: SsdsFilterForm,
  'power-supplies': PowerSuppliesFilterForm,
};

export function ProductsPage() {
  const { category } = useParams<{ category: string }>();
  const { data: products } = useProducts(category ?? '');

  if (!products || !category) {
    return (
      <Page>
        <Loader />
      </Page>
    );
  }

  const FilterForm = filterForms[category];

  if (!FilterForm) return <Navigate to='/404' />;

  return (
    <Page>
      <div className='flex flex-col lg:flex-row items-center lg:items-start gap-20'>
        <FilterForm />
        <ProductsList products={products} category={category} />
      </div>
    </Page>
  );
}
