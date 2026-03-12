import { useTranslation } from '@/features/language/hooks/useTranslation';
import { ContactInformationForm } from '../components/ContactInformationForm';
import { Page } from '@/components/layout/Page';
import { z } from 'zod';
import { RadioGroup, RadioGroupItem } from '@/components/ui/radio-group';
import { useShipments } from '../hooks/useShipments';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';
import { useForm } from 'react-hook-form';
import { Form } from '@/components/ui/form';
import { FormField, FormItem, FormControl } from '@/components/ui/form';
import { useState } from 'react';
import { Payment } from '../components/Payment';
import { Button } from '@/components/ui/button';

export const billingSchema = z.object({
  countryId: z.number().min(1, 'Country is required'),
  cityId: z.number().min(1, 'City is required'),
  streetName: z.string().min(1, 'Street name is required'),
  streetNumber: z.number().min(1, 'Street number is required'),
  floor: z.number().optional(),
  apartmentNumber: z.number().optional(),
  shipmentId: z.number().min(1, 'Shipment is required')
});

export type Billing = z.infer<typeof billingSchema>;

export function BillingPage() {
  const [shippingCost, setShippingCost] = useState<number>(0);
  const [isProceeded, setIsProceeded] = useState(false);
  const form = useForm<Billing>();

  const {
    components: { billingForm }
  } = useTranslation();

  const { data: shipments = [] } = useShipments();
  const sign = useCurrencyStore((store) => store.currency.sign);

  return (
    <Page>
      <Form {...form}>
        <div className='max-w-8xl mx-auto flex flex-col gap-6'>
          <div className='grid md:grid-cols-3 gap-6'>
            <ContactInformationForm />

            <FormField
              control={form.control}
              name='shipmentId'
              render={({ field }) => (
                <FormItem>
                  <FormControl>
                    <RadioGroup
                      value={field.value?.toString()}
                      onValueChange={(val) => {
                        field.onChange(Number(val));
                        const opt = shipments.find(
                          (o) => o.id.toString() === val
                        );
                        setShippingCost(opt?.cost ?? 0);
                      }}
                      className='flex flex-col gap-3'
                    >
                      {shipments.map((opt) => (
                        <label
                          key={opt.id}
                          className='flex items-start gap-3 rounded-lg border p-3 cursor-pointer hover:border-primary transition-all'
                        >
                          <RadioGroupItem
                            value={opt.id.toString()}
                            className='mt-1'
                          />

                          <div className='flex flex-col'>
                            <span className='text-sm font-medium'>
                              {opt.shipmentType}
                            </span>

                            <span className='text-xs text-muted-foreground'>
                              {opt.days === 0
                                ? 'Same day'
                                : `${opt.days} day(s)`}
                            </span>

                            <span className='text-sm font-semibold'>
                              {sign}
                              {opt.cost}
                            </span>
                          </div>
                        </label>
                      ))}
                    </RadioGroup>
                  </FormControl>
                </FormItem>
              )}
            />

            {isProceeded && (
              <Payment billing={form.getValues()} shippingCost={shippingCost} />
            )}
          </div>

          <div className='flex flex-col gap-2 max-w-2xl'>
            <h3 className='font-medium'>{billingForm.returnPolicyLabel}</h3>
            <p className='text-sm text-muted-foreground'>
              {billingForm.returnPolicyText}
            </p>
          </div>

          <div className='flex justify-center items-center mt-5'>
            <Button
              onClick={() => setIsProceeded(true)}
              className='bg-theme-crimson hover:bg-theme-gunmetal self-start transition-colors duration-300 cursor-pointer'
            >
              Submit
            </Button>
          </div>
        </div>
      </Form>
    </Page>
  );
}
