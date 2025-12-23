import { useState } from 'react';

export function useQuantityControl(maxQuantity: number) {
  const [quantity, setQuantity] = useState(1);

  const handleQuantityIncrease = () => {
    setQuantity((previousQuantity) =>
      Math.min(maxQuantity, previousQuantity + 1)
    );
  };

  const handleQuantityDecrease = () => {
    setQuantity((previousQuantity) => Math.max(1, previousQuantity - 1));
  };

  return {
    quantity,
    handleQuantityIncrease,
    handleQuantityDecrease,
  };
}
