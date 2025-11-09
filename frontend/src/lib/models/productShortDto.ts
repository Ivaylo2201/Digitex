import type { Price } from "./Price";

export interface ProductShortDto {
  id: string;               
  sku: string;
  brandName: string;
  modelName: string;
  imagePath: string;
  price: Price;
  discountPercentage: number;
  rating: number;           
  isTop: boolean;
}