import {
  Controller,
  type Control,
  type UseFormSetValue,
} from 'react-hook-form';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { Checkbox } from '@/components/ui/checkbox';
import { Label } from '@/components/ui/label';
import { Button } from '@/components/ui/button';
import { RangeSlider } from '../RangeSlider';
import { Fragment } from 'react/jsx-runtime';
import type React from 'react';

type FilterFormProps = React.PropsWithChildren<{
  brands: string[];
  control: Control<any>;
  setValue: UseFormSetValue<any>;
}>;

export function FilterForm({
  brands,
  control,
  setValue,
  children,
}: FilterFormProps) {
  const {
    components: { filterForm },
  } = useTranslation();

  return (
    <Fragment>
      <div className='flex flex-col gap-4'>
        <p className='font-semibold text-theme-gunmetal'>{filterForm.brands}</p>
        {brands.map((brand) => (
          <Controller
            key={brand}
            name='brands'
            control={control}
            render={({ field }) => {
              const value = Array.isArray(field.value) ? field.value : [];

              return (
                <div className='flex gap-3'>
                  <Checkbox
                    id={brand}
                    checked={value.includes(brand)}
                    onCheckedChange={(checked) => {
                      if (checked) {
                        field.onChange([...value, brand]);
                      } else {
                        field.onChange(value.filter((b) => b !== brand));
                      }
                    }}
                    className='cursor-pointer data-[state=checked]:bg-theme-crimson data-[state=checked]:border-theme-crimson border-gray-300'
                  />
                  <Label htmlFor={brand} className='cursor-pointer'>
                    {brand}
                  </Label>
                </div>
              );
            }}
          />
        ))}
      </div>

      <Controller
        name='price'
        control={control}
        render={() => (
          <RangeSlider
            title={filterForm.price}
            onChange={(range) =>
              setValue('price', { min: range[0], max: range[1] })
            }
            min={0}
            max={5000}
            step={100}
          />
        )}
      />

      {children}

      <Button
        type='submit'
        className='w-full bg-theme-crimson hover:bg-theme-lightcrimson cursor-pointer duration-200 transition-colors'
      >
        Apply
      </Button>
    </Fragment>
  );
}
