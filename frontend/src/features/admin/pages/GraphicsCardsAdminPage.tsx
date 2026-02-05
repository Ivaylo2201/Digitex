import { Page } from '@/components/layout/Page';
import { GraphicsCardsDatatable } from '../components/GraphicsCardsDatatable';
import { GraphicsCardForm } from '../components/GraphicsCardsForm';

export function GraphicsCardsAdminPage({}) {
  return (
    <Page>
      <div className='flex flex-col items-start'>
        <GraphicsCardForm />
        <GraphicsCardsDatatable />
      </div>
    </Page>
  );
}
