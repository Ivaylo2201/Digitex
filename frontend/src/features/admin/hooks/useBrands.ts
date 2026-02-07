import { staleTime } from '@/lib/api/constants';
import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';

async function fetchBrands() {
  const res =
    await httpClient.get<{ id: number; brandName: string }[]>('/brands');
  return res.data;
}

export function useBrands() {
  return useQuery({
    queryKey: ['brands'],
    queryFn: fetchBrands,
    staleTime: staleTime,
  });
}
