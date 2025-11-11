type Price = {
  initial: number;
  discounted: number;
}

export type ProductShort = {
  id: string;               
  brandName: string;
  modelName: string;
  imagePath: string;
  price: Price;
  discountPercentage: number;
  rating: number;           
}