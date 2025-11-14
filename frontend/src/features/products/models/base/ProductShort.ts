export type ProductShort = {
  id: string;
  brandName: string;
  modelName: string;
  imagePath: string;
  price: {
    initial: number;
    discounted: number;
  };
  discountPercentage: number;
  rating: number;
};
