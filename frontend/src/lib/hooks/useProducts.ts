import { useSuspenseQuery } from "@tanstack/react-query";
import { http } from "@/lib/http";
import type { ProductShort } from "../models/products/ProductShort";

async function getProducts(category: string) {
  const res = await http.get<ProductShort[]>(`/products/${category}`);
  return res.data;
}

export default function useProducts(category: string) {
  return useSuspenseQuery({
    queryKey: ["products", category],
    queryFn: () => getProducts(category),
    staleTime: 60 * 60 * 1000,
    retry: false,
  });
}
