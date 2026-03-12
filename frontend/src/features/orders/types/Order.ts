import type { OrderItem } from './OrderItem';

export type Order = {
  items: OrderItem[];
  billingAddress: string;
  shipmentType: string;
  totalPrice: number;
};
