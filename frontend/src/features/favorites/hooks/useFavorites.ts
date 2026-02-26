import { useAuthStore } from '@/features/auth/stores/useAuth';
import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';

async function fetchFavorites() {
  const res = await httpClient.get('/favorites');
  return res.data;
}

export function useFavorites() {
  const isAuthenticated = useAuthStore((store) => store.isAuthenticated);

  return useQuery({
    queryKey: ['favorites'],
    queryFn: fetchFavorites,
    staleTime: staleTime,
    enabled: isAuthenticated
  });
}
