import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';
import type { Country } from '../types/Country';

async function fetchCountries() {
  const res = await httpClient.get<Country[]>('/countries');
  return res.data;
}

export function useCountries() {
  return useQuery({
    queryKey: ['countries'],
    queryFn: fetchCountries,
  });
}
