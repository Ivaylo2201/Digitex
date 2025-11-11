import type { ProductLong } from "@/lib/models/products/ProductLong";
import Page from "./Page";

type ProductPageProps = {
  product: ProductLong;
  formattedData: Record<string, string>;
};

export default function ProductPage({
  product,
  formattedData,
}: ProductPageProps) {
  return (
    <Page>
      {Object.entries(formattedData).map(([key, value]) => (
        <div key={key}>
          <strong>{key}:</strong> {value}
        </div>
      ))}
    </Page>
  );
}
