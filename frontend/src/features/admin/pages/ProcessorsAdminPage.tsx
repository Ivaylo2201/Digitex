import { Page } from '@/components/layout/Page';
import { ProcessorForm } from '../components/forms/ProcessorForm';
import { ProcessorsDataTable } from '../components/datatables/ProcessorsDataTable';

export function ProcessorsAdminPage() {
  return (
    <Page>
      <div className='flex flex-col items-start'>
        <ProcessorForm />
        <ProcessorsDataTable />
      </div>
    </Page>
  );
}
