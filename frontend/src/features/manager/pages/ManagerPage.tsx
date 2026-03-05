import { Page } from '@/components/layout/Page';
import { SalesChart } from '../components/SalesChart';
import { CategorySalesPieChart } from '../components/CategorySalesPieChart';
import { TotalRevenueCard } from '../components/TotalRevenueCard';

export function ManagerPage() {
  return (
    <Page>
      <div className='flex justify-center'>
        <SalesChart />
        <div className='flex flex-col gap-10'>
          <TotalRevenueCard />
          <CategorySalesPieChart />
        </div>
      </div>
    </Page>
  );
}
