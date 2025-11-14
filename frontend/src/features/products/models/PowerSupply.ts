import type { ProductLong } from './base/ProductLong';

export type PowerSupply = ProductLong & {
  wattage: number;
  formFactor: string;
  efficiencyPercentage: number;
  modularity: string;
};
