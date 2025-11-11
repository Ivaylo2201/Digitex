import useProduct from "@/lib/hooks/useProduct";
import type { GraphicsCard } from "@/lib/models/products/GraphicsCard";
import ProductPage from "../base/ProductPage";

export default function GraphicsCardProductPage() {
  const { data: product } = useProduct<GraphicsCard>("graphics-cards");

  return <ProductPage product={product} data={{}} />
}
