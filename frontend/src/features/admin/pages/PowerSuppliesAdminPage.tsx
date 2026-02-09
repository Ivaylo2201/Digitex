import { Page } from '@/components/layout/Page';
import { PowerSuppliesDataTable } from '../components/datatables/PowerSuppliesDataTable';
import { PowerSupplyForm } from '../components/forms/PowerSupplyForm';

export function PowerSuppliesAdminPage() {
  return (
    <Page>
      <div className='flex flex-col items-start'>
        <PowerSupplyForm />
        <PowerSuppliesDataTable />
      </div>
    </Page>
  );
}
