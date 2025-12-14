import { FormProvider, useForm } from 'react-hook-form';
import type { BaseFilters } from '../../types/BaseFilters';
import { useFilters } from '../../hooks/useFilters';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { FilterForm } from './FilterForm';
import { OptionsList } from '../OptionsList';
import { RangeSlider } from '../RangeSlider';

type SsdsFilters = BaseFilters & {
  memoryCapacities: number[];
  storageInterfaces: string[];
  minReadSpeed: number;
  minWriteSpeed: number;
  maxReadSpeed: number;
  maxWriteSpeed: number;
};

export function SsdsFilterForm() {
  const form = useForm<SsdsFilters>();
  const { data } = useFilters<SsdsFilters>('ssds');

  const {
    components: { ssdsFilterForm },
    units,
  } = useTranslation();

  const setReadSpeedRange = (range: [number, number]) => {
    form.setValue('minReadSpeed', range[0]);
    form.setValue('maxReadSpeed', range[1]);
  };

  const setWriteSpeedRange = (range: [number, number]) => {
    form.setValue('minWriteSpeed', range[0]);
    form.setValue('maxWriteSpeed', range[1]);
  };

  return (
    <FormProvider {...form}>
      <FilterForm brands={data?.brands ?? []}>
        <OptionsList
          options={data?.memoryCapacities}
          control={form.control}
          onDisplay={(memoryCapacity) => `${memoryCapacity} ${units.gigabytes}`}
          name='memoryCapacities'
          title={ssdsFilterForm.memoryCapacity}
        />
        <OptionsList
          options={data?.storageInterfaces}
          control={form.control}
          name='storageInterfaces'
          title={ssdsFilterForm.storageInterface}
        />
        <RangeSlider
          title={ssdsFilterForm.readSpeed}
          onChange={setReadSpeedRange}
          min={data?.minReadSpeed ?? 1000}
          max={data?.maxReadSpeed ?? 10000}
          step={100}
          urlValues={['minReadSpeed', 'maxReadSpeed']}
          onFormat={(value) => `${value} ${units.mbPerSecond}`}
        />
        <RangeSlider
          title={ssdsFilterForm.writeSpeed}
          onChange={setWriteSpeedRange}
          min={data?.minWriteSpeed ?? 1000}
          max={data?.maxWriteSpeed ?? 10000}
          step={100}
          urlValues={['minWriteSpeed', 'maxWriteSpeed']}
          onFormat={(value) => `${value} ${units.mbPerSecond}`}
        />
      </FilterForm>
    </FormProvider>
  );
}
