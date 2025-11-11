import useProduct from "@/lib/hooks/useProduct";
import type { Monitor } from "@/lib/models/products/Monitor";
import ProductPage from "../base/ProductPage";
import { useTranslation } from "@/lib/stores/useTranslation";

export default function MonitorsProductPage() {
  const { data: product } = useProduct<Monitor>();
  const translation = useTranslation();

  const formattedData = {
    displayDiagonal: `${product.displayDiagonal}"`,
    refreshRate: `${product.refreshRate} Hz`,
    latency: `${product.latency} ms`,
    matrix: product.matrix,
    resolution: `${product.resolution.width}x${product.resolution.height}`,
    pixelSize: `${product.pixelSize} µm`,
    brightness: `${product.brightness} cd/m²`,
    colorSpectre: `${product.colorSpectre} %`,
  };

  return <ProductPage product={product} formattedData={formattedData} />;
}
