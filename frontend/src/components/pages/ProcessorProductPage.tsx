import type { Processor } from "@/lib/models/products/Processor";
import ProductPage from "./base/ProductPage";
import useProduct from "@/lib/hooks/useProduct";

export default function ProcessorProductPage() {
  const { data: product } = useProduct<Processor>();

  return <ProductPage product={product}></ProductPage>;
}
