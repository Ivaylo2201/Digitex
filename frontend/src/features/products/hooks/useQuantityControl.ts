import { useState } from 'react';

export function useQuantityControl(
  initialQuantity: number,
  maxQuantity: number,
  onChange?: (quantity: number) => void
) {
  const [quantity, setQuantity] = useState(initialQuantity);

  const handleQuantityIncrease = () => {
    setQuantity((previousQuantity) => {
      const quantity = Math.min(maxQuantity, previousQuantity + 1);
      onChange?.(quantity);
      return quantity;
    });
  };

  const handleQuantityDecrease = () => {
    setQuantity((previousQuantity) => {
      const quantity = Math.max(1, previousQuantity - 1);
      onChange?.(quantity);
      return quantity;
    });
  };

  return { quantity, handleQuantityIncrease, handleQuantityDecrease };
}
