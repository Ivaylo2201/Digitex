import { Page } from '@/components/layout/Page';
import { SsdForm } from '../components/forms/SsdForm';
import { SsdsDataTable } from '../components/datatables/SsdsDataTable';

export function SsdsAdminPage() {
  return (
    <Page>
      <div className='flex flex-col items-start'>
        <SsdForm />
        <SsdsDataTable />
      </div>
    </Page>
  );
}
