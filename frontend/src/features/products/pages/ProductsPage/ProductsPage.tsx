import { Navigate, useParams } from 'react-router';
import { Page } from '@/components/layout/Page';
import { useProducts } from '../../hooks/useProducts';
import { Loader } from '../../components/Loader';
import { ProductsList } from './components/ProductsList';
import { GraphicsCardsFilterForm } from '@/features/filters/components/forms/GraphicsCardsFilterForm';
import { MotherboardsFilterForm } from '@/features/filters/components/forms/MotherboardsFilterForm';
import { ProcessorsFilterForm } from '@/features/filters/components/forms/ProcessorsFilterForm';
import { RamsFilterForm } from '@/features/filters/components/forms/RamFilterForm';
import { MonitorsFilterForm } from '@/features/filters/components/forms/MonitorsFilterForm';
import { SsdsFilterForm } from '@/features/filters/components/forms/SsdsFilterForm';
import { PowerSuppliesFilterForm } from '@/features/filters/components/forms/PowerSuppliesFilterForm';
import { useEffect, useState } from 'react';
import { ProductsPagination } from './components/ProductsPagination';
import type { GraphicsCard } from '../../models/GraphicsCard';

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
  const [page, setPage] = useState(1);
  const { data } = useProducts<GraphicsCard>(category ?? '', page, 9);

  useEffect(() => {
    setPage(1);
  }, [category]);

  if (!data?.items || !category) {
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
      <div className='flex flex-col gap-10'>
        <div className='flex flex-col lg:flex-row items-center lg:items-start gap-20'>
          <FilterForm />
          <ProductsList products={data.items} category={category} />
        </div>
        <ProductsPagination
          page={page}
          pageSize={9}
          setPage={setPage}
          totalPages={data.totalPages}
        />
      </div>
    </Page>
  );
}
