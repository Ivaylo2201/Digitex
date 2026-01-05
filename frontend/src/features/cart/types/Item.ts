import type { Product } from './Product';

export type Item = {
  id: number;
  product: Product;
  quantity: number;
  lineTotal: number;
};
