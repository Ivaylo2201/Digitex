import type { ProductLong } from './base/ProductLong';

export type Motherboard = ProductLong & {
  socket: string;
  formFactor: string;
  chipset: any;
  ramSlots: number;
  pcieSlots: number;
};
