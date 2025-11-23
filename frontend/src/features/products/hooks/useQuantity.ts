import { useState } from 'react';

const ITEM_MIN_QUANTITY = 1;
const ITEM_MAX_QUANTITY = 15;

export default function useQuantity(q: number = 1) {
  const [quantity, setQuantity] = useState<number>(q);

  const handleQuantityChange = (q: number) => {
    if (q >= ITEM_MIN_QUANTITY && q <= ITEM_MAX_QUANTITY) {
      setQuantity(q);
    }
  };

  return { quantity, handleQuantityChange };
}
