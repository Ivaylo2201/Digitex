import { useSuspenseQuery } from "@tanstack/react-query";
import { http } from "../http";
import { useParams } from "react-router";

async function getProduct<T>(category?: string, id?: string) {
  const res = await http.get<T>(`/products/${category}/${id}`);
  return res.data;
}

export default function useProduct<T>(category: string) {
  const id = useParams<{ id: string }>().id;

  return useSuspenseQuery({
    queryKey: [category, id],
    queryFn: () => getProduct<T>(category, id),
    staleTime: 60 * 60 * 1000,
    retry: false,
  });
}
