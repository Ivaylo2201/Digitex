import { Controller, useFormContext } from 'react-hook-form';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { Button } from '@/components/ui/button';
import { RangeSlider } from '../RangeSlider';
import type React from 'react';
import { OptionsList } from '../OptionsList';

type FilterFormProps = React.PropsWithChildren<{
  brands: string[];
}>;

export function FilterForm({ brands, children }: FilterFormProps) {
  const {
    components: { filterForm },
  } = useTranslation();

  const { control, setValue } = useFormContext();

  return (
    <div className='flex flex-col gap-4 w-56'>
      <OptionsList
        options={brands}
        control={control}
        name='brands'
        title={filterForm.brands}
      />

      <RangeSlider
        title={filterForm.price}
        onChange={(range) => {
          setValue('minPrice', range[0]);
          setValue('maxPrice', range[1]);
        }}
        min={0}
        max={5000}
        step={100}
      />

      {children}

      <Button
        type='submit'
        className='w-full bg-theme-crimson hover:bg-theme-lightcrimson cursor-pointer duration-200 transition-colors mt-5'
      >
        {filterForm.apply}
      </Button>
    </div>
  );
}
