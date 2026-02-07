import { Page } from '@/components/layout/Page';
import { MotherboardForm } from '../components/forms/MotherboardForm';
import { MotherboardsDataTable } from '../components/datatables/MotherboardsDataTable';

export function MotherboardsAdminPage() {
  return (
    <Page>
      <div className='flex flex-col items-start'>
        <MotherboardForm />
        <MotherboardsDataTable />
      </div>
    </Page>
  );
}
