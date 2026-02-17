import type { ApiError } from '@/lib/api/ApiError';
import { httpClient } from '@/lib/api/httpClient';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import type { AxiosResponse } from 'axios';

export function useToggleFavorite() {
  const queryClient = useQueryClient();

  return useMutation<AxiosResponse<void>, ApiError, { productId: string }>({
    mutationFn: async (data) => {
      return httpClient.post<void>('/favorites/toggle', data);
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['favorites'] });
    },
  });
}
