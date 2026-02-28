import { Page } from '@/components/layout/Page';
import { SalesChart } from '../components/SalesChart';
import { CategorySalesPieChart } from '../components/CategorySalesPieChart';
import { TotalRevenueCard } from '../components/TotalRevenueCard';

type ManagerPageProps = {};

export function ManagerPage({}: ManagerPageProps) {
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
