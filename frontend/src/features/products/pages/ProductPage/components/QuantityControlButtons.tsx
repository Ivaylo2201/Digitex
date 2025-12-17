import { Button } from '@/components/ui/button';
import { Minus, Plus } from 'lucide-react';

type QuantityControlButtonsProps = {
  quantity: number;
  handleQuantityIncrease: () => void;
  handleQuantityDecrease: () => void;
};

export function QuantityControlButtons({
  quantity,
  handleQuantityIncrease,
  handleQuantityDecrease,
}: QuantityControlButtonsProps) {
  return (
    <div className='flex justify-center items-center'>
      <Button
        onClick={handleQuantityDecrease}
        disabled={quantity === 1}
        className='size-9 rounded-full bg-theme-gunmetal text-white cursor-pointer hover:bg-theme-crimson duration-200 transition-colors'
      >
        <Minus />
      </Button>
      <span className='w-10 text-center text-theme-gunmetal font-medium'>
        {quantity}
      </span>
      <Button
        onClick={handleQuantityIncrease}
        disabled={quantity === 20}
        className='size-9 rounded-full bg-theme-gunmetal text-white cursor-pointer hover:bg-theme-crimson duration-200 transition-colors'
      >
        <Plus />
      </Button>
    </div>
  );
}
