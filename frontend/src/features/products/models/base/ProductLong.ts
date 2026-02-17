import type { Review } from '../../../reviews/models/Review';
import type { SuggestedProduct } from '../shared/SuggestedProduct';
import type { ProductShort } from './ProductShort';

export type ProductLong = ProductShort & {
  sku: string;
  totalReviews: number;
  recentReviews: Review[];
  suggestions: SuggestedProduct[];
};
