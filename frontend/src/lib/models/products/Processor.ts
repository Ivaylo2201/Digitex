import type { ClockSpeed } from "../shared/ClockSpeed";
import type { ProductLong } from "./ProductLong";

export type Processor = ProductLong & {
  cores: number;
  threads: number;
  clockSpeed: ClockSpeed;
  socket: string;
  tdp: number;
};
