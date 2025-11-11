import useProduct from "@/lib/hooks/useProduct";
import type { Ssd } from "@/lib/models/products/Ssd";
import ProductPage from "../base/ProductPage";

export default function SsdProductPage() {
  const { data: product } = useProduct<Ssd>();

  return <ProductPage product={product}>Processor-specific stuff</ProductPage>;
}
