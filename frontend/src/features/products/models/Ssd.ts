import type { ProductLong } from './base/ProductLong';

export type Ssd = ProductLong & {
  capacityInGb: number;
  operationSpeed: {
    read: number;
    write: number;
  };
  interface: any;
};
