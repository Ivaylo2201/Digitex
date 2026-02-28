import { Pie, PieChart, Cell } from 'recharts';

import {
  Card,
  CardContent,
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
import { useCategorySales } from '../hooks/useCategorySales';

export const description = 'Category sales distribution';

const SLICE_COLORS = [
  'var(--color-theme-crimson)',
  'var(--color-theme-gunmetal)',
];

const chartConfig = {
  percentage: {
    label: 'Percentage',
  },
} satisfies ChartConfig;

export function CategorySalesPieChart() {
  const { data } = useCategorySales();

  const normalize = (input: string) => {
    return input
      .split('-')
      .map((x) => x.charAt(0).toUpperCase() + x.slice(1))
      .join(' ');
  };

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
                  formatter={(_, __, item) => {
                    const percent = item?.payload?.percentage ?? 0;
                    const count = item?.payload?.count ?? 0;
                    const category = item?.payload?.category ?? '';
                    return `${normalize(category)} - ${percent}% (${count})`;
                  }}
                />
              }
            />

            <Pie data={data} dataKey='percentage' nameKey='category'>
              {data?.map((_, index) => (
                <Cell
                  key={`cell-${index}`}
                  fill={SLICE_COLORS[index % SLICE_COLORS.length]}
                />
              ))}
            </Pie>
          </PieChart>
        </ChartContainer>
      </CardContent>

      <CardFooter className='flex-col gap-2 text-sm'>
        <div className='flex items-center gap-2 leading-none font-medium'>
          Distribution by percentage
        </div>
      </CardFooter>
    </Card>
  );
}
