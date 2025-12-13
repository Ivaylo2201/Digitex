import { FormProvider, useForm } from 'react-hook-form';
import { useFilters } from '../../hooks/useFilters';
import { FilterForm } from './FilterForm';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { OptionsList } from '../OptionsList';
import { RangeSlider } from '../RangeSlider';
import type { GraphicsCardsFilters } from '../../types/GraphicsCardsFilters';

export function GraphicsCardsFilterForm() {
  const form = useForm<GraphicsCardsFilters>();
  const { data } = useFilters<GraphicsCardsFilters>('graphics-cards');

  const {
    components: { graphicsCardsFilterForm },
    units,
  } = useTranslation();

  const setClockSpeedRange = (range: [number, number]) => {
    form.setValue('minClockSpeed', range[0]);
    form.setValue('maxClockSpeed', range[1]);
  };

  return (
    <form>
      <FormProvider {...form}>
        <FilterForm brands={data?.brands ?? []} category='graphics-cards'>
          <OptionsList
            options={data?.busWidths}
            control={form.control}
            onDisplay={(busWidth) => `${busWidth} ${units.bits}`}
            name='busWidth'
            title={graphicsCardsFilterForm.busWidth}
          />
          <OptionsList
            options={data?.memoryCapacities}
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
            onFormat={(value) => `${value.toFixed(1)} ${units.gigahertz}`}
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
