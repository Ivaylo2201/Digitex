import { useParams } from 'react-router';
import { Page } from '@/components/layout/Page';
import { useProducts } from '../../hooks/useProducts';
import { Loader } from './components/Loader';
import { ProductsList } from './components/ProductsList';
import { GraphicsCardsFilterForm } from '@/features/filters/components/forms/GraphicsCardsFilterForm';

const filterForms: Record<string, React.ComponentType> = {
  'graphics-cards': GraphicsCardsFilterForm,
};

export function ProductsPage() {
  const { category } = useParams<{ category: string }>();
  const { data: products } = useProducts(category);
  const isLoading = products === undefined || category === undefined;

  if (isLoading) {
    return (
      <Page>
        <Loader />
      </Page>
    );
  }

  const FilterForm = filterForms[category];

  return (
    <Page>
      <div className='flex flex-col lg:flex-row items-center lg:items-start gap-20'>
        <FilterForm />
        <ProductsList products={products} category={category} />
      </div>
    </Page>
  );
}
