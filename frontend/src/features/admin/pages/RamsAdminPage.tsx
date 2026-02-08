import { Page } from '@/components/layout/Page';
import { RamForm } from '../components/forms/RamForm';
import { RamDataTable } from '../components/datatables/RamDataTable';

export function RamsAdminPage() {
  return (
    <Page>
      <div className='flex flex-col items-start'>
        <RamForm />
        <RamDataTable />
      </div>
    </Page>
  );
}
