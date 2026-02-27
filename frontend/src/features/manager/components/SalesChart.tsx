import { ChartContainer, type ChartConfig } from '@/components/ui/chart';
import { Bar, BarChart, XAxis, YAxis, CartesianGrid, Tooltip } from 'recharts';
import { useSales } from '../hooks/useSales';

const chartConfig = {
  revenue: {
    label: 'Revenue',
    color: '#16a34a',
  },
  sales: {
    label: 'Sales',
    color: '#dc2626',
  },
} satisfies ChartConfig;

export function SalesChart() {
  const { data } = useSales();

  const allMonths = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December',
  ];

  const chartData = allMonths.map((month) => {
    const found = data?.find((d) => d.month === month);
    return found || { month, sales: 0, revenue: 0 };
  });

  return (
    <ChartContainer config={chartConfig} className='min-h-[300px] w-full'>
      <BarChart data={chartData} barGap={4} barCategoryGap='20%'>
        <CartesianGrid vertical={false} />
        <XAxis dataKey='month' />
        <YAxis />
        <Tooltip
          content={({ active, payload, label }) => {
            if (!active || !payload) return null;

            const revenue = payload.find((p) => p.dataKey === 'revenue')?.value;
            const sales = payload.find((p) => p.dataKey === 'sales')?.value;

            return (
              <div className='bg-theme-gunmetal text-white p-2 rounded shadow'>
                <strong>{label}</strong>
                <div>Revenue: €{revenue}</div>
                <div>Sales: {sales}</div>
              </div>
            );
          }}
        />

        <Bar
          dataKey='revenue'
          fill='var(--color-theme-crimson)'
          radius={4}
          barSize={40}
        />
        <Bar
          dataKey='sales'
          fill='var(--color-theme-gunmetal)'
          radius={4}
          barSize={40}
        />
      </BarChart>
    </ChartContainer>
  );
}
