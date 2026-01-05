import { useState, useEffect } from 'react';
import { Button } from '@/components/ui/button';
import { useShipments } from '../hooks/useShipments';
import { RadioGroup, RadioGroupItem } from '@/components/ui/radio-group';

interface Props {
  subtotal: number;
}

export function ShipmentSelector({ subtotal }: Props) {
  const { data: shipments, isLoading } = useShipments();
  const [selectedShipmentId, setSelectedShipmentId] = useState<number | null>(
    null
  );

  useEffect(() => {
    if (shipments && shipments.length > 0 && selectedShipmentId === null) {
      setSelectedShipmentId(shipments[0].id);
    }
  }, [shipments, selectedShipmentId]);

  if (isLoading) return <div>Loading shipment options...</div>;
  if (!shipments || shipments.length === 0)
    return <div>No shipment options available.</div>;

  const selectedShipment = shipments.find((s) => s.id === selectedShipmentId);

  return (
    <div className='p-6 rounded-xl border bg-white max-w-md mx-auto space-y-4'>
      <h2 className='text-lg font-bold'>Select Shipment Type</h2>

      <RadioGroup
        value={selectedShipmentId?.toString()}
        onValueChange={(v) => setSelectedShipmentId(Number(v))}
        className='flex flex-col space-y-2'
      >
        {shipments.map((s) => (
          <label
            key={s.id}
            className='flex justify-between items-center p-3 border rounded-md cursor-pointer transition hover:border-theme-crimson'
          >
            <div className='flex flex-col'>
              <span className='font-medium'>{s.shipmentType}</span>
              <span className='text-sm text-muted-foreground'>
                ${s.cost} — {s.days} {s.days === 1 ? 'day' : 'days'}
              </span>
            </div>
            <RadioGroupItem
              value={s.id.toString()}
              className='accent-theme-crimson'
            />
          </label>
        ))}
      </RadioGroup>

      <div className='flex justify-between text-base font-medium pt-4 border-t'>
        <span>Subtotal:</span>
        <span>${subtotal + (selectedShipment?.cost ?? 0)}</span>
      </div>

      <Button className='w-full mt-4'>Proceed to Checkout</Button>
    </div>
  );
}
