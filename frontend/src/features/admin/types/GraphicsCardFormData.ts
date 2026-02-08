import type { BaseFormData } from "./BaseFormData";

export type GraphicsCardFormData = BaseFormData & {
  memory: {
    capacityInGb: number;
    type: string;
    frequency: number;
  };
  clockSpeed: {
    base: number;
    boost: number;
  };
  busWidth: number;
  cudaCores: number;
  directXSupport: number;
  tdp: number;
};
