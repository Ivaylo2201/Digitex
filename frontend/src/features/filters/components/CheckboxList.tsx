import { Checkbox } from '@/components/ui/checkbox';
import { Label } from '@/components/ui/label';

type CheckboxListProps<T extends string | number> = {
  title: string;
  data: T[];
  onFormat?: (value: string) => string;
};

export function CheckboxList<T extends string | number>({
  title,
  data,
  onFormat,
}: CheckboxListProps<T>) {
  return (
    <div className='flex flex-col gap-4'>
      <p className='font-semibold text-theme-gunmetal'>{title}</p>
      {data.map((value, index) => (
        <div className='flex gap-3' key={index}>
          <Checkbox
            id={value.toString()}
            className='cursor-pointer data-[state=checked]:bg-theme-crimson data-[state=checked]:border-theme-crimson border-gray-300'
          />
          <Label htmlFor={value.toString()} className='cursor-pointer'>
            {onFormat ? onFormat(value.toString()) : value}
          </Label>
        </div>
      ))}
    </div>
  );
}
