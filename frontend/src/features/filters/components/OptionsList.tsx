import { Checkbox } from '@/components/ui/checkbox';
import { Label } from '@/components/ui/label';
import { useEffect } from 'react';
import { useController, type Control } from 'react-hook-form';

type OptionsListProps = {
  options?: (string | number)[];
  control: Control<any>;
  name: string;
  title: string;
  onDisplay?: (value: string) => string;
};

export function OptionsList({
  options,
  control,
  name,
  title,
  onDisplay,
}: OptionsListProps) {
  const { field } = useController({ name, control });

  useEffect(() => {
    if (!field.value || field.value.length === 0) {
      const queryParam = new URLSearchParams(window.location.search).get(name);
      if (queryParam) {
        field.onChange(queryParam.split(','));
      }
    }
  }, []);

  const values = Array.isArray(field.value) ? field.value : [];

  return (
    <div className='flex flex-col gap-4'>
      <p className='font-semibold text-theme-gunmetal'>{title}</p>

      <ul className='flex flex-col gap-3'>
        {(options ?? []).map((option) => {
          const optionString = option.toString();

          return (
            <li key={optionString} className='flex gap-3'>
              <Checkbox
                id={optionString}
                checked={values.includes(optionString)}
                onCheckedChange={(checked) =>
                  field.onChange(
                    checked
                      ? [...values, optionString]
                      : values.filter((value) => value !== optionString)
                  )
                }
                className='cursor-pointer data-[state=checked]:bg-theme-crimson data-[state=checked]:border-theme-crimson border-gray-300'
              />
              <Label htmlFor={optionString} className='cursor-pointer'>
                {onDisplay ? onDisplay(optionString) : optionString}
              </Label>
            </li>
          );
        })}
      </ul>
    </div>
  );
}
