import { Controller, FormProvider, useForm } from 'react-hook-form';
import type { BaseFilters } from '../../types/BaseFilters';
import { useFilters } from '../../hooks/useFilters';
import { FilterForm } from './FilterForm';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { OptionsList } from '../OptionsList';
import { RangeSlider } from '../RangeSlider';
import { useApplyFilter } from '../../hooks/useApplyFilter';

export type GraphicsCardsFilters = BaseFilters & {
  busWidth: number[];
  memoryCapacity: number[];
  minClockSpeed: number;
  maxClockSpeed: number;
  cudaCores: number[];
};

export function GraphicsCardsFilterForm() {
  const form = useForm<GraphicsCardsFilters>();
  const { data } = useFilters<GraphicsCardsFilters>('graphics-cards');
  const { applyFilter } = useApplyFilter('graphics-cards');
  const { units } = useTranslation();

  if (!data) return;

  return (
    <form onSubmit={form.handleSubmit(applyFilter)}>
      <FormProvider {...form}>
        <FilterForm brands={data.brands}>
          <OptionsList
            options={data.busWidth}
            control={form.control}
            onDisplay={(busWidth) => `${busWidth} ${units.bits}`}
            name='busWidth'
            title='Bus widths'
          />
          <OptionsList
            options={data.memoryCapacity}
            control={form.control}
            onDisplay={(memoryCapacity) =>
              `${memoryCapacity} ${units.gigabytes}`
            }
            name='memoryCapacity'
            title='Memory capacity'
          />
          <RangeSlider
            title={'Clock speed'}
            onChange={(range) => {
              form.setValue('minClockSpeed', range[0]);
              form.setValue('maxClockSpeed', range[1]);
            }}
            min={0}
            max={5000}
            step={100}
          />
          <OptionsList
            options={data.cudaCores}
            control={form.control}
            name='cudaCores'
            title='Cuda cores'
          />
        </FilterForm>
      </FormProvider>
    </form>
  );
}
