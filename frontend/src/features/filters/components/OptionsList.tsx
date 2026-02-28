import { Checkbox } from '@/components/ui/checkbox';
import { Label } from '@/components/ui/label';
import { useEffect } from 'react';
import {
  useController,
  type Control,
  type FieldValues,
  type Path,
} from 'react-hook-form';

type OptionsListProps<T extends FieldValues> = {
  options?: (string | number)[];
  control: Control<T>;
  name: Path<T>;
  title: string;
  onDisplay?: (value: string) => string;
};

export function OptionsList<T extends FieldValues>({
  options,
  control,
  name,
  title,
  onDisplay,
}: OptionsListProps<T>) {
  const { field } = useController({ name, control });

  useEffect(() => {
    if (!field.value || field.value.length === 0) {
      const queryParam = new URLSearchParams(window.location.search).get(
        `Criteria[${name}]`,
      );
      if (queryParam) {
        field.onChange(queryParam.split(','));
      }
    }
  }, []);

  const values: string[] = Array.isArray(field.value) ? field.value : [];

  return (
    <div className='flex flex-col gap-2.5'>
      <p className='font-semibold text-theme-gunmetal'>{title}</p>

      <ul className='flex flex-col gap-3.5'>
        {(options ?? []).map((option) => {
          const optionString = option.toString();

          return (
            <li key={optionString} className='flex gap-2.5'>
              <Checkbox
                id={optionString}
                checked={values.includes(optionString)}
                onCheckedChange={(checked) =>
                  field.onChange(
                    checked
                      ? [...values, optionString]
                      : values.filter((value) => value !== optionString),
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
