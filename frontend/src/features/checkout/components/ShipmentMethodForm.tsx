import { RadioGroup, RadioGroupItem } from '@/components/ui/radio-group';
import { Controller, useFormContext } from 'react-hook-form';
import type { Billing } from './BillingForm';
import { useShipments } from '../hooks/useShipments';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';

export function ShipmentMethodForm() {
  const { control } = useFormContext<Billing>();
  const { data: shipments = [] } = useShipments();
  const sign = useCurrencyStore(store => store.currency.sign)

  console.log(shipments)

  return (
    <Controller
      control={control}
      name='shipmentId'
      render={({ field }) => (
        <RadioGroup
          value={field.value?.toString() || ''}
          onValueChange={(val) => field.onChange(Number(val))}
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
                <span className='text-sm font-semibold'>{sign}{opt.cost}</span>
              </div>
            </label>
          ))}
        </RadioGroup>
      )}
    />
  );
}
