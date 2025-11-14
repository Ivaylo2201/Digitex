import type { Review } from '../../../reviews/models/Review';
import type { ProductShort } from './ProductShort';

export type ProductLong = ProductShort & {
  sku: string;
  reviews: Review[];
};
