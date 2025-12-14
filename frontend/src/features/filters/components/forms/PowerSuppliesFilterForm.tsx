import { FormProvider, useForm } from 'react-hook-form';
import type { BaseFilters } from '../../types/BaseFilters';
import { useFilters } from '../../hooks/useFilters';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { FilterForm } from './FilterForm';
import { OptionsList } from '../OptionsList';
import { RangeSlider } from '../RangeSlider';

type PowerSuppliesFilters = BaseFilters & {
  formFactors: string[];
  modularities: string[];
  minEfficiencyPercentage: number;
  maxEfficiencyPercentage: number;
};

export function PowerSuppliesFilterForm() {
  const form = useForm<PowerSuppliesFilters>();
  const { data } = useFilters<PowerSuppliesFilters>('power-supplies');

  const {
    components: { powerSuppliesFilterForm },
  } = useTranslation();

  const setEfficiencyPercentageRange = (range: [number, number]) => {
    form.setValue('minEfficiencyPercentage', range[0]);
    form.setValue('maxEfficiencyPercentage', range[1]);
  };

  return (
    <FormProvider {...form}>
      <FilterForm brands={data?.brands ?? []}>
        <OptionsList
          options={data?.formFactors}
          control={form.control}
          name='formFactors'
          title={powerSuppliesFilterForm.formFactor}
        />
        <OptionsList
          options={data?.modularities}
          control={form.control}
          name='modularities'
          title={powerSuppliesFilterForm.modularity}
        />
        <RangeSlider
          title={powerSuppliesFilterForm.efficiencyPercentage}
          onChange={setEfficiencyPercentageRange}
          min={data?.minEfficiencyPercentage ?? 0}
          max={data?.maxEfficiencyPercentage ?? 100}
          step={1}
          urlValues={['minEfficiencyPercentage', 'maxEfficiencyPercentage']}
          onFormat={(value) => `${value}%`}
        />
      </FilterForm>
    </FormProvider>
  );
}
