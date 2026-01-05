import type { Item } from './Item';

export type Cart = {
  items: Item[];
  totalPrice: number;
};
