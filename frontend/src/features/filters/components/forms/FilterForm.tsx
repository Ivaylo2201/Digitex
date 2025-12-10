import { Controller, useForm } from 'react-hook-form';
import type { BaseFilters } from '../../types/BaseFilters';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { Checkbox } from '@/components/ui/checkbox';
import { Label } from '@/components/ui/label';
import { Button } from '@/components/ui/button';
import { RangeSlider } from '../RangeSlider';

type FilterFormProps = {
  brands: string[];
};

export function FilterForm({ brands }: FilterFormProps) {
  const { handleSubmit, control, setValue } = useForm<BaseFilters>({
    defaultValues: { brands: [] },
  });
  const {
    components: { filterForm },
  } = useTranslation();

  return (
    <form onSubmit={handleSubmit((data) => console.log(data))}>
      <div className='flex flex-col gap-4'>
        <p className='font-semibold text-theme-gunmetal'>{filterForm.brands}</p>
        {brands.map((brand) => (
          <Controller
            key={brand}
            name='brands'
            control={control}
            render={({ field }) => (
              <div className='flex gap-3' key={brand}>
                <Checkbox
                  id={brand}
                  checked={field.value.includes(brand)}
                  onCheckedChange={(checked) => {
                    if (checked) {
                      field.onChange([...field.value, brand]);
                    } else {
                      field.onChange(field.value.filter((b) => b !== brand));
                    }
                  }}
                  className='cursor-pointer data-[state=checked]:bg-theme-crimson data-[state=checked]:border-theme-crimson border-gray-300'
                />
                <Label htmlFor={brand} className='cursor-pointer'>
                  {brand}
                </Label>
              </div>
            )}
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

      <Button
        type='submit'
        className='w-full bg-theme-crimson hover:bg-theme-lightcrimson cursor-pointer duration-200 transition-colors'
      >
        {filterForm.apply}
      </Button>
    </form>
  );
}
