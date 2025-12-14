import { FormProvider, useForm } from 'react-hook-form';
import { useFilters } from '../../hooks/useFilters';
import type { BaseFilters } from '../../types/BaseFilters';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { FilterForm } from './FilterForm';
import { OptionsList } from '../OptionsList';

type RamsFilters = BaseFilters & {
  memoryCapacities: number[];
  memoryTypes: string[];
  frequencies: number[];
};

export function RamsFilterForm() {
  const form = useForm<RamsFilters>();
  const { data } = useFilters<RamsFilters>('rams');

  const {
    components: { graphicsCardsFilterForm },
    units,
  } = useTranslation();

  return (
    <FormProvider {...form}>
      <FilterForm brands={data?.brands ?? []}>
        <OptionsList
          options={data?.memoryCapacities}
          control={form.control}
          onDisplay={(memoryCapacity) => `${memoryCapacity} ${units.gigabytes}`}
          name='memoryCapacities'
          title={graphicsCardsFilterForm.memoryCapacity}
        />
        <OptionsList
          options={data?.memoryTypes}
          control={form.control}
          name='memoryTypes'
          title={'memoryTypes'}
        />
        <OptionsList
          options={data?.frequencies}
          control={form.control}
          name='frequencies'
          title={'frequency'}
          onDisplay={(frequency) => `${frequency} ${units.megahertz}`}
        />
      </FilterForm>
    </FormProvider>
  );
}
