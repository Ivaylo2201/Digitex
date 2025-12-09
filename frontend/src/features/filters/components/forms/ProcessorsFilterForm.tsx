import { useFilters } from '../../hooks/useFilters';
import type { BaseFilters } from '../../types/BaseFilters';
import { FilterForm } from './FilterForm';

export function ProcessorsFilterForm() {
  const { data: filters } = useFilters<BaseFilters>('processors');

  if (filters === undefined) {
    return null;
  }

  return <FilterForm filters={filters}></FilterForm>;
}
