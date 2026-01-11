import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';
import type { Shipment } from '../types/Shipment';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';

async function fetchShipments(currencyIsoCode: string) {
  const res = await httpClient.get<Shipment[]>('/shipments', {
    params: { currency: currencyIsoCode },
  });
  return res.data;
}

export function useShipments() {
  const currencyIsoCode = useCurrencyStore(
    (state) => state.currency.currencyIsoCode
  );

  return useQuery({
    queryKey: ['shipments', currencyIsoCode],
    queryFn: () => fetchShipments(currencyIsoCode),
  });
}
