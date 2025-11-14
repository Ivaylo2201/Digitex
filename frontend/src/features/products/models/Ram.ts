import type { ProductLong } from './base/ProductLong';
import type { Memory } from './shared/Memory';

export type Ram = ProductLong & {
  memory: Memory;
  timing: string;
};
