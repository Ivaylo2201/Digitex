import type { Review } from '../../../reviews/models/Review';
import type { ProductShort } from './ProductShort';

type SuggestedProduct = {
  id: string;
  category: string;
  brandName: string;
  modelName: string;
  imagePath: string;
}

export type ProductLong = ProductShort & {
  sku: string;
  reviews: Review[];
  suggestedProducts: SuggestedProduct[];
};
