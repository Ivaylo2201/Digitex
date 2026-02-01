import { Page } from '@/components/layout/Page';
import { GraphicsCardsUpsertForm } from '../components/forms/variants/GraphicsCardsUpsertForm';
import { GraphicsCardsDatatable } from '../components/tables/variants/GraphicsCardsDatatable';

export function GraphicsCardsAdminPage({}) {
  return (
    <Page>
      <div className='flex flex-col items-start'>
        <GraphicsCardsUpsertForm />
        <GraphicsCardsDatatable />
      </div>
    </Page>
  );
}
