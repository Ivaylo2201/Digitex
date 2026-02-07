import { Page } from '@/components/layout/Page';
import { GraphicsCardForm } from '../components/forms/GraphicsCardsForm';
import { GraphicsCardsDataTable } from '../components/datatables/GraphicsCardsDataTable';

export function GraphicsCardsAdminPage({}) {
  return (
    <Page>
      <div className='flex flex-col items-start'>
        <GraphicsCardForm />
        <GraphicsCardsDataTable />
      </div>
    </Page>
  );
}
