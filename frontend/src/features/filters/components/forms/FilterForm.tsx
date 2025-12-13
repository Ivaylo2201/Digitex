import { useFormContext } from 'react-hook-form';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { RangeSlider } from '../RangeSlider';
import type React from 'react';
import { OptionsList } from '../OptionsList';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';
import { useQueryClient } from '@tanstack/react-query';
import { useEffect } from 'react';
import { useLocation, useNavigate } from 'react-router';
import { toQueryParams } from '../../utils/toQueryParams';

type FilterFormProps = React.PropsWithChildren<{
  brands: string[];
  category: string;
}>;

export function FilterForm({ brands, category, children }: FilterFormProps) {
  const {
    components: { filterForm },
  } = useTranslation();

  const { control, setValue, handleSubmit, watch } = useFormContext();
  const { currency } = useCurrencyStore();
  const queryClient = useQueryClient();
  const location = useLocation();
  const navigate = useNavigate();

  const onSubmit = (data: object) => {
    navigate(`${location.pathname}?${toQueryParams(data)}`, { replace: true });
    queryClient.invalidateQueries({ queryKey: ['products', category] });
  };

  useEffect(() => {
    const subscription = watch(() => handleSubmit(onSubmit)());
    return () => subscription.unsubscribe();
  }, [watch, handleSubmit]);

  return (
    <div className='flex flex-col gap-8 w-56' onSubmit={handleSubmit(onSubmit)}>
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
        onFormat={(value) => `${currency.sign}${value.toFixed(2)}`}
        min={0}
        max={5000}
        step={100}
      />

      {children}
    </div>
  );
}
