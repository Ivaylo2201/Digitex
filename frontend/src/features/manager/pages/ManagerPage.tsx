import { Page } from '@/components/layout/Page';
import { SalesChart } from '../components/SalesChart';
import { CategorySalesPieChart } from '../components/CategorySalesPieChart';
import { TotalRevenueCard } from '../components/TotalRevenueCard';
import { MostSoldProductCard } from '../components/MostSoldProductCard';

export function ManagerPage() {
  return (
    <Page>
      <div className='flex justify-center gap-10'>
        <SalesChart />
        <div className='flex flex-col gap-10 '>
          <TotalRevenueCard />
          <CategorySalesPieChart />
          <MostSoldProductCard />
        </div>
      </div>
    </Page>
  );
}
