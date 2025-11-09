import { useSuspenseQuery } from "@tanstack/react-query";
import { http } from "../http";
import type { ProductShortDto } from "../models/productShortDto";

type UseProductsResponse = ProductShortDto[];

async function getProducts(category: string | undefined) {
  const res = await http.get<UseProductsResponse>(
    `/products/${category}`
  );
  return res.data;
}

export default function useProducts(category: string | undefined) {
  return useSuspenseQuery({
    queryKey: ['products', category],
    queryFn: () => getProducts(category),
    staleTime: 60 * 60 * 1000,
    retry: false
  });
}