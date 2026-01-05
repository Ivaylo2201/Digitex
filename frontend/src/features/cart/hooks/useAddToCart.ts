import { useTranslation } from "@/features/language/hooks/useTranslation";
import type { ApiError } from "@/lib/api/ApiError";
import { httpClient } from "@/lib/api/httpClient";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import type { AxiosResponse } from "axios";
import { toast } from "sonner";

type UseAddToCartRequest = { productId: string; quantity: number };

async function addToCart(data: UseAddToCartRequest) {
  const res = await httpClient.post('/carts', data);
  return res.data;
}

export function useAddToCart() {
  const queryClient = useQueryClient();
  const { hooks } = useTranslation();

  return useMutation<AxiosResponse, ApiError, UseAddToCartRequest>({
    mutationFn: addToCart,
    onSuccess: () => {
      toast.success(hooks.useAddToCart.productSuccessfullyAddedToCart)
      queryClient.invalidateQueries({ queryKey: ['cart'] });
    },
    onError: () => toast.error(hooks.generic.somethingWentWrong)
  });
}