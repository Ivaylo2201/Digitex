import { Slider } from '@/components/ui/slider';

type MarksSliderProps<T extends string | number> = { marks: T[] };

export function MarksSlider<T extends string | number>({
  marks,
}: MarksSliderProps<T>) {
  return (
    <div className='w-full max-w-sm'>
      <Slider defaultValue={[1]}  step={1} />
      <div className='mt-2 -mx-1.5 flex items-center justify-between text-muted-foreground text-xs'>
        {marks.map((mark, index) => (
          <span key={index}>{mark}</span>
        ))}
      </div>
    </div>
  );
}