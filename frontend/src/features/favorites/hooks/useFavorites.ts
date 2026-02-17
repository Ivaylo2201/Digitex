import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';

async function fetchFavorites() {
  const res = await httpClient.get('/favorites');
  console.log(res.data)
  return res.data;
}

export function useFavorites() {
  return useQuery({
    queryKey: ['favorites'],
    queryFn: fetchFavorites,
    staleTime: staleTime,
  });
}
