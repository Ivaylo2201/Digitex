import { useFormContext } from 'react-hook-form';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { Button } from '@/components/ui/button';
import { RangeSlider } from '../RangeSlider';
import type React from 'react';
import { OptionsList } from '../OptionsList';
import { useEffect } from 'react';
import { useCurrency } from '@/features/currency/stores/useCurrency';
import { getCurrencySymbol } from '@/features/currency/utils/getCurrencySymbol';

type FilterFormProps = React.PropsWithChildren<{
  brands: string[];
  applyFilter: (data: object) => void;
}>;

export function FilterForm({ brands, applyFilter, children }: FilterFormProps) {
  const {
    components: { filterForm },
  } = useTranslation();

  const { watch, control, setValue, handleSubmit } = useFormContext();
  const { currency } = useCurrency();

  useEffect(() => {
    const subscription = watch((values) => {
      handleSubmit(() => applyFilter(values))();
    });
    return () => subscription.unsubscribe();
  }, [watch, handleSubmit, applyFilter]);

  return (
    <div className='flex flex-col gap-8 w-56'>
      <OptionsList
        options={brands}
        control={control}
        name='brands'
        title={filterForm.brand}
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
        onFormat={(value) => `${getCurrencySymbol(currency)}${value.toFixed(2)}`}
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
