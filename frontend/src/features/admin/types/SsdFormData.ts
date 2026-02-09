import type { BaseFormData } from './BaseFormData';

export type SsdFormData = BaseFormData & {
  capacityInGb: number;
  operationSpeed: {
    read: number;
    write: number;
  };
  storageInterface: string;
};
