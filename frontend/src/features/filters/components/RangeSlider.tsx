import { RangeSlider as Slider } from '@/components/ui/range-slider';
import { parseNumber } from '@/lib/utils/parseNumber';
import { useState } from 'react';
import { useLocation } from 'react-router';

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
  const location = useLocation();

  const [range, setRange] = useState(() => {
    const queryParams = Object.fromEntries(
      new URLSearchParams(location.search)
    );
    return [
      parseNumber(queryParams.minPrice) ?? 0,
      parseNumber(queryParams.maxPrice) ?? 5000,
    ];
  });

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
