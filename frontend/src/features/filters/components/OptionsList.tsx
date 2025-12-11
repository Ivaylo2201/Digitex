import { Checkbox } from '@/components/ui/checkbox';
import { Label } from '@/components/ui/label';
import { useController, type Control } from 'react-hook-form';

type OptionsListProps = {
  options: (string | number)[];
  control: Control<any>;
  name: string;
  title: string;
  onDisplay?: (value: string | number) => string;
};

export function OptionsList({
  options,
  control,
  name,
  title,
  onDisplay,
}: OptionsListProps) {
  const { field } = useController({ name, control });
  const values = Array.isArray(field.value) ? field.value : [];

  return (
    <div className='flex flex-col gap-4'>
      <p className='font-semibold text-theme-gunmetal'>{title}</p>

      <ul className='flex flex-col gap-3'>
        {options.map((option) => (
          <li key={option.toString()} className='flex gap-3'>
            <Checkbox
              id={option.toString()}
              checked={values.includes(option)}
              onCheckedChange={(checked) =>
                field.onChange(
                  checked
                    ? [...values, option]
                    : values.filter((value) => value !== option)
                )
              }
              className='cursor-pointer data-[state=checked]:bg-theme-crimson data-[state=checked]:border-theme-crimson border-gray-300'
            />
            <Label htmlFor={option.toString()} className='cursor-pointer'>
              {onDisplay ? onDisplay(option) : option}
            </Label>
          </li>
        ))}
      </ul>
    </div>
  );
}
