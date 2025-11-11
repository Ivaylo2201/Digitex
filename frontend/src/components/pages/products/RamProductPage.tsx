import type { Ram } from "@/lib/models/products/Ram";
import ProductPage from "../base/ProductPage";
import useProduct from "@/lib/hooks/useProduct";

export default function RamProductPage() {
  const { data: product } = useProduct<Ram>("rams");

  return <ProductPage product={product} data={{}} />
}
