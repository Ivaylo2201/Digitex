import type { BaseFilters } from './BaseFilters';

export type GraphicsCardsFilters = BaseFilters & {
  busWidth: number[];
  memoryCapacity: number[];
  baseClockSpeed: number[];
  cudaCores: number[];
};
