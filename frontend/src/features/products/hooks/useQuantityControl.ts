import { useState } from 'react';

const MINIMUM_QUANTITY = 1;
const MAXIMUM_QUANTITY = 20;

export function useQuantityControl() {
  const [quantity, setQuantity] = useState(MINIMUM_QUANTITY);

  const handleQuantityIncrease = () => {
    setQuantity((previousQuantity) => Math.min(MAXIMUM_QUANTITY, previousQuantity + 1));
  };

  const handleQuantityDecrease = () => {
    setQuantity((previousQuantity) => Math.max(MINIMUM_QUANTITY, previousQuantity - 1));
  };

  return {
    quantity,
    handleQuantityIncrease,
    handleQuantityDecrease,
  };
}
