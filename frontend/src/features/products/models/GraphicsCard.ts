import type { ProductLong } from './base/ProductLong';
import type { ClockSpeed } from './shared/ClockSpeed';
import type { Memory } from './shared/Memory';

export type GraphicsCard = ProductLong & {
  memory: Memory;
  clockSpeed: ClockSpeed;
  busWidth: number;
  cudaCores: number;
  directXSupport: number;
  tdp: number;
};
