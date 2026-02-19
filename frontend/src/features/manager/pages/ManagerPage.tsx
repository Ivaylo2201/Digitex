import { Page } from '@/components/layout/Page';
import { MostSoldProductsTable } from '../components/MostSoldProductsTable';
import { SalesChart } from '../components/SalesChart';
import { PieChart } from 'lucide-react';
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
