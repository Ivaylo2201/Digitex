import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';
import { type Review } from '../models/Review';

async function fetchReviews(productId: string) {
  const res = await httpClient.get<Review[]>('/reviews', {
    params: { productId: productId },
  });
  return res.data;
}

export function useReviews(productId: string) {
  return useQuery({
    queryKey: ['reviews', productId],
    queryFn: () => fetchReviews(productId),
  });
}
