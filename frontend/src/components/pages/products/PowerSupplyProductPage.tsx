import useProduct from "@/lib/hooks/useProduct";
import type { PowerSupply } from "@/lib/models/products/PowerSupply";
import ProductPage from "../base/ProductPage";

export default function PowerSupplyProductPage() {
  const { data: product } = useProduct<PowerSupply>("power-supplies");

  return <ProductPage product={product} data={{}} />
}
