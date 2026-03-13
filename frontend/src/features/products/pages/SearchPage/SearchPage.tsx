import { Page } from '@/components/layout/Page';
import { SearchList } from './components/SearchList';
import { useSearchedProducts } from './hooks/useSearchedProducts';
import { useSearchParams } from 'react-router';
import { Loader } from '../../components/Loader';

export function SearchPage() {
  const [searchParams] = useSearchParams();
  const { data } = useSearchedProducts(searchParams.get('query') ?? '');

  if (!data) {
    return (
      <Page>
        <Loader />
      </Page>
    );
  }

  return (
    <Page>
      <div className='flex flex-col gap-10'>
        <div className='flex flex-col lg:flex-row items-center lg:items-start gap-20'>
          <SearchList products={data} />
        </div>
      </div>
    </Page>
  );
}
