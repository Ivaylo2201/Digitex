import { Page } from '@/components/layout/Page';
import { MonitorsDataTable } from '../components/datatables/MonitorsDataTable';
import { MonitorForm } from '../components/forms/MonitorForm';

export function MonitorsAdminPage() {
  return (
    <Page>
      <div className='flex flex-col items-start'>
        <MonitorForm />
        <MonitorsDataTable />
      </div>
    </Page>
  );
}
