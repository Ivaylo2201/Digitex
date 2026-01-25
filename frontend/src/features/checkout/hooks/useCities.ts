import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';
import type { City } from '../types/City';

async function fetchCities(countryId: number) {
  const res = await httpClient.get<City[]>('/cities', {
    params: { countryId },
  });
  return res.data;
}

export function useCities(countryId: number | undefined) {
  return useQuery({
    queryKey: ['cities', countryId],
    queryFn: () => fetchCities(countryId!),
    enabled: countryId !== undefined,
  });
}
