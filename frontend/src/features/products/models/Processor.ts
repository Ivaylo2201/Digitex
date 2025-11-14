import type { ProductLong } from './base/ProductLong';
import type { ClockSpeed } from './shared/ClockSpeed';

export type Processor = ProductLong & {
  cores: number;
  threads: number;
  clockSpeed: ClockSpeed;
  socket: string;
  tdp: number;
};
