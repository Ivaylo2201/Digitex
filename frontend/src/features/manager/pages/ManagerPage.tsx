import { Page } from '@/components/layout/Page';
import { SalesChart } from '../components/SalesChart';
import { CategorySalesPieChart } from '../components/CategorySalesPieChart';

type ManagerPageProps = {};

export function ManagerPage({}: ManagerPageProps) {
  return (
    <Page>
      {/* <MostSoldProductsTable /> */}
      <SalesChart />
      <CategorySalesPieChart />
    </Page>
  );
}
