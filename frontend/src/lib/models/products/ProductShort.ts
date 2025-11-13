import type { Price } from "../shared/Price";

export type ProductShort = {
  id: string;               
  brandName: string;
  modelName: string;
  imagePath: string;
  price: Price;
  discountPercentage: number;
  rating: number;           
}