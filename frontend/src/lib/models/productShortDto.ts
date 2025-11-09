import type { Price } from "@/lib/models/Price";

export interface ProductShortDto {
  id: string;               
  brandName: string;
  modelName: string;
  imagePath: string;
  price: Price;
  discountPercentage: number;
  rating: number;           
  isTop: boolean;
}