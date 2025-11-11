import type { ProductLong } from "./ProductLong";

export type Motherboard = ProductLong & {
  socket: string;
  formFactor: string;
  chipset: any; // fix later
  ramSlots: number;
  pcieSlots: number;
};
