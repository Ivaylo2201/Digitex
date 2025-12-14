import { FormProvider, useForm } from 'react-hook-form';
import type { BaseFilters } from '../../types/BaseFilters';
import { useFilters } from '../../hooks/useFilters';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { FilterForm } from './FilterForm';
import { OptionsList } from '../OptionsList';
import { RangeSlider } from '../RangeSlider';

type ProcessorsFilters = BaseFilters & {
  cores: number[];
  threads: number[];
  sockets: string[];
  minTdp: number;
  maxTdp: number;
};

export function ProcessorsFilterForm() {
  const form = useForm<ProcessorsFilters>();
  const { data } = useFilters<ProcessorsFilters>('processors');

  const {
    components: { processorsFilterForm },
    units,
  } = useTranslation();

  const setTdpRange = (range: [number, number]) => {
    form.setValue('minTdp', range[0]);
    form.setValue('maxTdp', range[1]);
  };

  return (
    <FormProvider {...form}>
      <FilterForm brands={data?.brands ?? []}>
        <OptionsList
          options={data?.cores}
          control={form.control}
          name='cores'
          title={processorsFilterForm.cores}
        />
        <OptionsList
          options={data?.threads}
          control={form.control}
          name='threads'
          title={processorsFilterForm.threads}
        />
        <OptionsList
          options={data?.sockets}
          control={form.control}
          name='sockets'
          title={processorsFilterForm.socket}
        />
        <RangeSlider
          title={processorsFilterForm.tdp}
          onChange={setTdpRange}
          min={data?.minTdp ?? 0}
          max={data?.maxTdp ?? 250}
          step={10}
          onFormat={(value) => `${value} ${units.watts}`}
        />
      </FilterForm>
    </FormProvider>
  );
}
