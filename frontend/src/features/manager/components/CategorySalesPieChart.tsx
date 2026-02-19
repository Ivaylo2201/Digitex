'use client';

import { TrendingUp } from 'lucide-react';
import { LabelList, Pie, PieChart, Cell } from 'recharts';

import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from '@/components/ui/card';
import {
  ChartContainer,
  ChartTooltip,
  ChartTooltipContent,
  type ChartConfig,
} from '@/components/ui/chart';

export const description = 'Category sales distribution';

const chartData = [
  { category: 'Graphics Cards', revenue: 500000 },
  { category: 'Monitors', revenue: 400000 },
  { category: 'Keyboards', revenue: 70000 },
  { category: 'Mice', revenue: 30000 },
];

const totalRevenue = chartData.reduce((sum, item) => sum + item.revenue, 0);

const SLICE_COLORS = [
  'var(--color-theme-crimson)',
  'var(--color-theme-gunmetal)',
];

const chartConfig = {
  revenue: {
    label: 'Revenue',
  },
  'Graphics Cards': {
    label: 'Graphics Cards',
    color: 'var(--color-theme-crimson)',
  },
  Monitors: { label: 'Monitors', color: 'var(--color-theme-crimson)' },
  Keyboards: { label: 'Keyboards', color: 'var(--color-theme-crimson)' },
  Mice: { label: 'Mice', color: 'var(--color-theme-crimson)' },
} satisfies ChartConfig;

export function CategorySalesPieChart() {
  return (
    <Card className='flex flex-col'>
      <CardHeader className='items-center pb-0'>
        <CardTitle>Sales by Category</CardTitle>
      </CardHeader>

      <CardContent className='flex-1 pb-0'>
        <ChartContainer
          config={chartConfig}
          className='[&_.recharts-text]:fill-background mx-auto aspect-square max-h-[250px]'
        >
          <PieChart>
            <ChartTooltip
              content={
                <ChartTooltipContent
                  hideLabel
                  formatter={(_, _name, item) => {
                    const revenue = item?.payload?.revenue ?? 0;
                    const percent = ((revenue / totalRevenue) * 100).toFixed(0);
                    return `${percent}%`;
                  }}
                />
              }
            />

            <Pie data={chartData} dataKey='revenue' nameKey='category'>
              {chartData.map((_, index) => (
                <Cell
                  key={`cell-${index}`}
                  fill={SLICE_COLORS[index % SLICE_COLORS.length]}
                />
              ))}

              <LabelList
                dataKey='category'
                className='fill-background'
                stroke='none'
                fontSize={12}
              />
            </Pie>
          </PieChart>
        </ChartContainer>
      </CardContent>

      <CardFooter className='flex-col gap-2 text-sm'>
        <div className='flex items-center gap-2 leading-none font-medium'>
          Revenue increased by 8.4% this quarter{' '}
          <TrendingUp className='h-4 w-4' />
        </div>
      </CardFooter>
    </Card>
  );
}
