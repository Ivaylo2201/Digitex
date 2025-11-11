import type { ClockSpeed } from "../shared/ClockSpeed";
import type { Memory } from "../shared/Memory";
import type { ProductLong } from "./ProductLong";

export type GraphicsCard = ProductLong & {
  memory: Memory;
  clockSpeed: ClockSpeed;
  busWidth: number;
  cudaCores: number;
  directXSupport: number;
  tdp: number;
};
