import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card';
import { useTotalRevenue } from '../hooks/useTotalRevenue';
import { useTranslation } from '@/features/language/hooks/useTranslation';

export function TotalRevenueCard() {
  const { data } = useTotalRevenue();
  const {
    components: { totalRevenueCard },
  } = useTranslation();

  return (
    <Card className='bg-theme-gunmetal text-white'>
      <CardHeader>
        <CardTitle>{totalRevenueCard.totalRevenue}</CardTitle>
      </CardHeader>

      <CardContent>
        <div className='text-3xl font-bold'>€{data?.totalRevenue}</div>
      </CardContent>
    </Card>
  );
}
