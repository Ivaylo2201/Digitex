import type { Review } from "../Review";
import type { ProductShort } from "./ProductShort";

export type ProductLong = ProductShort & {
  sku: string;
  reviews: Review[];
};
