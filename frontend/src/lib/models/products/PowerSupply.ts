import type { ProductLong } from "./ProductLong";

export type PowerSupply = ProductLong & {
  wattage: number;
  formFactor: string;
  efficiencyPercentage: number;
  modularity: string;
};
