import { RangeSlider as Slider } from '@/components/ui/range-slider';
import { useState } from 'react';

type RangeSliderProps = {
  min?: number;
  max?: number;
  defaultValues?: { from: number; to: number };
  step?: number;
  title: string;
};

export function RangeSlider({
  min = 0,
  max = 5000,
  defaultValues = { from: min, to: max },
  step = 100,
  title,
}: RangeSliderProps) {
  const [value, setValue] = useState([defaultValues.from, defaultValues.to]);

  return (
    <div className='w-full max-w-sm mx-auto flex flex-col gap-2'>
      <p className='font-semibold text-theme-gunmetal mb-1'>{title}</p>
      <Slider
        value={value}
        onValueChange={setValue}
        min={min}
        max={max}
        step={step}
      />
      <div className='flex justify-between text-sm text-theme-gunmetal'>
        <span>{value[0]}</span>
        <span>{value[1]}</span>
      </div>
    </div>
  );
}
