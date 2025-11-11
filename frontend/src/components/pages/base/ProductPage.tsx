import type { ProductLong } from "@/lib/models/products/ProductLong";
import Page from "./Page";

type ProductPageProps = React.PropsWithChildren & { product: ProductLong };

export default function ProductPage({ children, product }: ProductPageProps) {
  return <Page>{children}</Page>;
}
