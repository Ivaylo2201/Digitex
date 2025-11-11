import type { ProductLong } from "./ProductLong";

type OperationSpeed = {
  read: number;
  write: number;
};

export type Ssd = ProductLong & {
  capacityInGb: number;
  operationSpeed: OperationSpeed;
  interface: any; // fix later
};
