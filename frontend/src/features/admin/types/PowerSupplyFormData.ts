import type { BaseFormData } from './BaseFormData';

export type PowerSupplyFormData = BaseFormData & {
  wattage: number;
  formFactor: string;
  efficiencyPercentage: number;
  modularity: string;
};
