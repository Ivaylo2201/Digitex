import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card';
import { useTotalRevenue } from '../hooks/useTotalRevenue';

export function TotalRevenueCard() {
  const { data } = useTotalRevenue();

  return (
    <Card className='bg-theme-gunmetal text-white'>
      <CardHeader>
        <CardTitle>Total Revenue</CardTitle>
      </CardHeader>

      <CardContent>
        <div className='text-3xl font-bold'>€{data?.totalRevenue}</div>
      </CardContent>
    </Card>
  );
}
