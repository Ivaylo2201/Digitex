import useProduct from "@/lib/hooks/useProduct";
import type { Motherboard } from "@/lib/models/products/Motherboard";
import ProductPage from "../base/ProductPage";

export default function MotherboardProductPage() {
  const { data: product } = useProduct<Motherboard>();

  return <ProductPage product={product}>Processor-specific stuff</ProductPage>;
}
