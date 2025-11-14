import type { ProductLong } from './base/ProductLong';

export type Monitor = ProductLong & {
  displayDiagonal: number;
  refreshRate: number;
  latency: number;
  matrix: string;
  resolution: {
    width: number;
    height: number;
    type: string;
  };
  pixelSize: number;
  brightness: number;
  colorSpectre: number;
};
