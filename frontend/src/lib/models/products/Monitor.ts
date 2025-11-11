import type { ProductLong } from "./ProductLong";

type Resolution = {
  width: number;
  height: number;
  type: string;
};

export type Monitor = ProductLong & {
  displayDiagonal: number;
  refreshRate: number;
  latency: number;
  matrix: string;
  resolution: Resolution;
  pixelSize: number;
  brightness: number;
  colorSpectre: number;
};
