import { RangeSlider as Slider } from '@/components/ui/range-slider';
import { useState } from 'react';

type RangeSliderProps = {
  min: number;
  max: number;
  step: number;
  title: string;
  onChange?: (value: [number, number]) => void;
  onFormat?: (value: number) => string;
};

export function RangeSlider({
  min,
  max,
  step,
  title,
  onChange,
  onFormat,
}: RangeSliderProps) {
  const [range, setRange] = useState([min, max]);

  const handleChange = (value: [number, number]) => {
    setRange(value);
    onChange?.(value);
  };

  return (
    <div className='w-full max-w-sm mx-auto flex flex-col gap-2'>
      <p className='font-semibold text-theme-gunmetal mb-1'>{title}</p>
      <Slider
        value={range}
        onValueChange={handleChange}
        min={min}
        max={max}
        step={step}
      />
      <div className='flex justify-between text-sm text-theme-gunmetal'>
        <span>{onFormat ? onFormat(range[0]) : range[0]}</span>
        <span>{onFormat ? onFormat(range[1]) : range[1]}</span>
      </div>
    </div>
  );
}
