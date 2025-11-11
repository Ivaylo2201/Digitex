import type { Memory } from "../shared/Memory";
import type { ProductLong } from "./ProductLong";

export type Ram = ProductLong & {
  memory: Memory;
  timing: string;
};
