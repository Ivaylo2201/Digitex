import type { BaseFormData } from './BaseFormData';

export type RamFormData = BaseFormData & {
  memory: {
    capacityInGb: number;
    type: string;
    frequency: number;
  };
  timing: string;
};
