import type { BaseFormData } from './BaseFormData';

export type MonitorFormData = BaseFormData & {
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
