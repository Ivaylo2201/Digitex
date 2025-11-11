import { useParams } from "react-router";
import Page from "./Page";
import useProduct from "@/lib/hooks/useProduct";

export default function ProductPage() {
  const { category, id } = useParams<{ category: string, id: string }>();

  type Product = {}; // TODO: Finish
  const { data: product } = useProduct<Product>(category, id);

  return <Page></Page>;
}
