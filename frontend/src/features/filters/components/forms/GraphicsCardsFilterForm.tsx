import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { useFilters } from '../../hooks/useFilters';
import type { GraphicsCardsFilters } from '../../types/GraphicsCardsFilters';
import { FilterForm } from './FilterForm';
import { CheckboxList } from '../CheckboxList';

export function GraphicsCardsFilterForm() {
  const { data: filters } = useFilters<GraphicsCardsFilters>('graphics-cards');
  //const { components: {}} = useTranslation();

  if (filters === undefined) {
    return null;
  }

  return (
    <FilterForm filters={filters}>
      <CheckboxList
        title='Memory capacity'
        data={filters.memoryCapacity}
        onFormat={(value) => `${value} GB`}
      />
    </FilterForm>
  );
}
