import { Controller, useForm } from 'react-hook-form';
import type { BaseFilters } from '../../types/BaseFilters';
import { useFilters } from '../../hooks/useFilters';
import { FilterForm } from './FilterForm';
import { Label } from '@/components/ui/label';
import { Input } from '@/components/ui/input';
import { toQueryParams } from '../../utils/toQueryParams';

export type GraphicsCardsFilters = BaseFilters & {
  busWidth: number[];
  memoryCapacity: number[];
  baseClockSpeed: number[];
  cudaCores: number[];
  name: string;
};

export function Form() {
  const { handleSubmit, control, setValue } = useForm<GraphicsCardsFilters>();
  const { data } = useFilters<GraphicsCardsFilters>('graphics-cards');

  if (!data) return;

  return (
    <form onSubmit={handleSubmit((data) => console.log(toQueryParams(data)))}>
      <FilterForm brands={data.brands} control={control} setValue={setValue}>
        <Controller
          name='name'
          control={control}
          render={({ field }) => (
            <div className='flex flex-col gap-1'>
              <Label htmlFor='name'>Name</Label>
              <Input id='name' placeholder='Enter your name' {...field} />
            </div>
          )}
        />
      </FilterForm>
    </form>
  );
}
