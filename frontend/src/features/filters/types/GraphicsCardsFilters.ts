import type { BaseFilters } from './BaseFilters';

export type GraphicsCardsFilters = BaseFilters & {
  busWidths: number[];
  memoryCapacities: number[];
  minClockSpeed: number;
  maxClockSpeed: number;
  cudaCores: number[];
};
