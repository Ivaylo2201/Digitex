import { useFormContext } from 'react-hook-form';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { RangeSlider } from '../RangeSlider';
import type React from 'react';
import { OptionsList } from '../OptionsList';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';
import { useLocation, useNavigate } from 'react-router';
import { toQueryParams } from '../../../../lib/utils/toQueryParams';
import { Button } from '@/components/ui/button';

type FilterFormProps = React.PropsWithChildren<{
  brands: string[];
}>;

export function FilterForm({ brands, children }: FilterFormProps) {
  const {
    components: { filterForm },
  } = useTranslation();

  const { control, setValue, handleSubmit } = useFormContext();
  const { currency } = useCurrencyStore();
  const location = useLocation();
  const navigate = useNavigate();

  const onSubmit = (data: object) => {
    const queryParams = Object.fromEntries(
      new URLSearchParams(location.search)
    );
    navigate(
      `${location.pathname}?${toQueryParams({ ...queryParams, ...data })}`,
      { replace: true }
    );
  };

  return (
    <form
      onSubmit={handleSubmit(onSubmit)}
      className='flex flex-col gap-6 w-56'
    >
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
        urlValues={['minPrice', 'maxPrice']}
        onFormat={(value) => `${currency.sign}${value.toFixed(2)}`}
        min={0}
        max={5000}
        step={100}
      />

      <div className='flex flex-col gap-6'>{children}</div>

      <Button
        type='submit'
        className='w-full bg-theme-crimson hover:bg-theme-lightcrimson cursor-pointer duration-200 transition-colors'
      >
        {filterForm.apply}
      </Button>
    </form>
  );
}
