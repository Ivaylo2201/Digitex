import { FormProvider, useForm } from 'react-hook-form';
import type { BaseFilters } from '../../types/BaseFilters';
import { FilterForm } from './FilterForm';
import { OptionsList } from '../OptionsList';
import { useFilters } from '../../hooks/useFilters';
import { useTranslation } from '@/features/language/hooks/useTranslation';

type MonitorsFilters = BaseFilters & {
  refreshRates: number[];
  matrices: string[];
  resolutionTypes: string[];
};

export function MonitorsFilterForm() {
  const form = useForm<MonitorsFilters>();
  const { data } = useFilters<MonitorsFilters>('monitors');
  const {
    components: { motherboardsFilterForm },
    units
  } = useTranslation();

  return (
    <FormProvider {...form}>
      <FilterForm brands={data?.brands ?? []}>
        <OptionsList
          options={data?.refreshRates}
          control={form.control}
          name='refreshRates'
          title={'refreshRates'}
          onDisplay={(refreshRate) => `${refreshRate} ${units.hertz}`}
        />
        <OptionsList
          options={data?.matrices}
          control={form.control}
          name='matrices'
          title={'matrices'}
        />
        <OptionsList
          options={data?.resolutionTypes}
          control={form.control}
          name='resolutionTypes'
          title={'resolutionTypes'}
        />
      </FilterForm>
    </FormProvider>
  );
}
