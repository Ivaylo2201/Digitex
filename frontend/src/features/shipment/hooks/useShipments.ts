import { httpClient } from '@/lib/api/httpClient';
import { useQuery } from '@tanstack/react-query';
import type { Shipment } from '../types/Shipment';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';

async function getShipments(currencyIsoCode: string) {
  const response = await httpClient.get<Shipment[]>(
    `/shipments?currency=${currencyIsoCode}`
  );
  return response.data;
}

export function useShipments() {
  const currencyIsoCode = useCurrencyStore(
    (state) => state.currency.currencyIsoCode
  );

  return useQuery({
    queryKey: ['shipments'],
    queryFn: () => getShipments(currencyIsoCode),
  });
}
