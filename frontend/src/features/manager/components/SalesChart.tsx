'use client';

import { ChartContainer, type ChartConfig } from '@/components/ui/chart';
import { Bar, BarChart, XAxis, YAxis, CartesianGrid, Tooltip } from 'recharts';

const chartData = [
  { date: 'Feb 01', revenue: 1240, orders: 18 },
  { date: 'Feb 02', revenue: 980, orders: 12 },
  { date: 'Feb 03', revenue: 1560, orders: 21 },
  { date: 'Feb 04', revenue: 720, orders: 9 },
  { date: 'Feb 05', revenue: 1890, orders: 26 },
  { date: 'Feb 06', revenue: 2100, orders: 31 },
  { date: 'Feb 07', revenue: 1750, orders: 24 },
];

const chartConfig = {
  revenue: {
    label: 'Revenue',
    color: '#16a34a',
  },
  orders: {
    label: 'Orders',
    color: '#2563eb',
  },
} satisfies ChartConfig;

export function SalesChart() {
  return (
    <ChartContainer config={chartConfig} className='min-h-[300px] w-full'>
      <BarChart accessibilityLayer data={chartData}>
        <CartesianGrid vertical={false} />
        <XAxis dataKey='date' />
        <YAxis />
        <Tooltip />
        <Bar dataKey='revenue' fill='var(--color-revenue)' radius={4} />
        <Bar dataKey='orders' fill='var(--color-orders)' radius={4} />
      </BarChart>
    </ChartContainer>
  );
}
