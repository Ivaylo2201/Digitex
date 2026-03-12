import type { Product } from "./Product"

export type OrderItem = {
  id: number
  product: Product
  quantity: number
  lineTotal: number
}