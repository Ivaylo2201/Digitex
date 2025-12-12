import { FormProvider, useForm } from 'react-hook-form';
import type { BaseFilters } from '../../types/BaseFilters';
import { useFilters } from '../../hooks/useFilters';
import { FilterForm } from './FilterForm';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { OptionsList } from '../OptionsList';
import { RangeSlider } from '../RangeSlider';
import { useApplyFilter } from '../../hooks/useApplyFilter';
import { useEffect } from 'react';

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
  const {
    components: { graphicsCardsFilterForm },
    units,
  } = useTranslation();

  useEffect(() => {
    const subscription = form.watch((values) => {
      form.handleSubmit(() => applyFilter(values))();
    });
    return () => subscription.unsubscribe();
  }, [form.watch, form.handleSubmit, applyFilter]);

  const setClockSpeedRange = (range: [number, number]) => {
    form.setValue('minClockSpeed', range[0]);
    form.setValue('maxClockSpeed', range[1]);
  };

  return (
    <form onSubmit={form.handleSubmit(applyFilter)}>
      <FormProvider {...form}>
        <FilterForm brands={data?.brands}>
          <OptionsList
            options={data?.busWidth}
            control={form.control}
            onDisplay={(busWidth) => `${busWidth} ${units.bits}`}
            name='busWidth'
            title={graphicsCardsFilterForm.busWidth}
          />
          <OptionsList
            options={data?.memoryCapacity}
            control={form.control}
            onDisplay={(memoryCapacity) =>
              `${memoryCapacity} ${units.gigabytes}`
            }
            name='memoryCapacity'
            title={graphicsCardsFilterForm.memoryCapacity}
          />
          <RangeSlider
            title={graphicsCardsFilterForm.clockSpeed}
            onChange={setClockSpeedRange}
            min={0}
            max={5}
            step={0.1}
          />
          <OptionsList
            options={data?.cudaCores}
            control={form.control}
            name='cudaCores'
            title={graphicsCardsFilterForm.cudaCores}
          />
        </FilterForm>
      </FormProvider>
    </form>
  );
}
