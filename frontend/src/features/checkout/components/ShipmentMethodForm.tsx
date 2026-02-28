import { RadioGroup, RadioGroupItem } from '@/components/ui/radio-group';
import { useShipments } from '../hooks/useShipments';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';

type ShipmentMethodFormProps = {
  shipmentId: number;
  setShipmentId: (val: number) => void;
};

export function ShipmentMethodForm({
  shipmentId,
  setShipmentId,
}: ShipmentMethodFormProps) {
  const { data: shipments = [] } = useShipments();
  const sign = useCurrencyStore((store) => store.currency.sign);

  return (
    <RadioGroup
      value={shipmentId.toString()}
      onValueChange={(val) => setShipmentId(Number(val))}
      className='grid grid-cols-2 gap-4'
    >
      {shipments.map((opt) => (
        <label
          key={opt.id}
          className='flex gap-3 rounded-lg border p-4 cursor-pointer
                         hover:border-primary data-[state=checked]:border-primary'
        >
          <RadioGroupItem value={opt.id.toString()} />

          <div className='flex flex-col gap-1'>
            <span className='text-sm font-medium'>{opt.shipmentType}</span>
            <span className='text-xs text-muted-foreground'>
              {opt.days === 0 ? 'Same day' : `${opt.days} day(s)`}
            </span>
            <span className='text-sm font-semibold'>
              {sign}
              {opt.cost}
            </span>
          </div>
        </label>
      ))}
    </RadioGroup>
  );
}
