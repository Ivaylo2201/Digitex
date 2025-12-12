import { FormProvider, useForm } from 'react-hook-form';
import type { BaseFilters } from '../../types/BaseFilters';
import { useFilters } from '../../hooks/useFilters';
import { useApplyFilter } from '../../hooks/useApplyFilter';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { FilterForm } from './FilterForm';
import { OptionsList } from '../OptionsList';

export type MotherboardsFilters = BaseFilters & {
  sockets: string[];
  formFactors: string[];
  chipsets: string[];
};

export function MotherboardsFilterForm() {
  const form = useForm<MotherboardsFilters>();
  const { data } = useFilters<MotherboardsFilters>('motherboards');
  const { applyFilter } = useApplyFilter('motherboards');
  const {
    components: { motherboardsFilterForm },
  } = useTranslation();

  if (!data) return;

  return (
    <form onSubmit={form.handleSubmit(applyFilter)}>
      <FormProvider {...form}>
        <FilterForm brands={data.brands} applyFilter={applyFilter}>
          <OptionsList
            options={data.sockets}
            control={form.control}
            name='sockets'
            title={motherboardsFilterForm.socket}
          />
          <OptionsList
            options={data.formFactors}
            control={form.control}
            name='formFactors'
            title={motherboardsFilterForm.formFactor}
          />
          <OptionsList
            options={data.chipsets}
            control={form.control}
            name='chipsets'
            title={motherboardsFilterForm.chipset}
          />
        </FilterForm>
      </FormProvider>
    </form>
  );
}
