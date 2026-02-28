import {
  Accordion,
  AccordionContent,
  AccordionItem,
  AccordionTrigger,
} from '@/components/ui/accordion';
import { ContactInformationForm } from './ContactInformationForm';
import { FormProvider, useForm } from 'react-hook-form';
import z from 'zod';
import { ShipmentMethodForm } from './ShipmentMethodForm';
import { useTranslation } from '@/features/language/hooks/useTranslation';

export const billingSchema = z.object({
  countryId: z.number().min(1, 'Country is required'),
  cityId: z.number().min(1, 'City is required'),
  streetName: z.string().min(1, 'Street name is required'),
  streetNumber: z.number().min(1, 'Street number is required'),
  floor: z.number().optional(),
  apartmentNumber: z.number().optional(),
});

export type Billing = z.infer<typeof billingSchema>;

type BillingFormProps = {
  shipmentId: number;
  setShipmentId: (val: number) => void;
};

export function BillingForm({ shipmentId, setShipmentId }: BillingFormProps) {
  const {
    components: { billingForm },
  } = useTranslation();
  const form = useForm<Billing>();

  return (
    <FormProvider {...form}>
      <Accordion
        type='single'
        collapsible
        defaultValue='item-1'
        className='w-72 md:w-[500px] bg-them-gunmetal'
      >
        <AccordionItem value='item-1'>
          <AccordionTrigger className='cursor-pointer'>
            {billingForm.contactInformation}
          </AccordionTrigger>
          <AccordionContent className='flex flex-col gap-4 text-balance'>
            <ContactInformationForm />
          </AccordionContent>
        </AccordionItem>
        <AccordionItem value='item-2'>
          <AccordionTrigger className='cursor-pointer'>
            {billingForm.shippingMethod}
          </AccordionTrigger>
          <AccordionContent className='flex flex-col gap-4 text-balance'>
            <ShipmentMethodForm
              shipmentId={shipmentId}
              setShipmentId={setShipmentId}
            />
          </AccordionContent>
        </AccordionItem>
        <AccordionItem value='item-3'>
          <AccordionTrigger className='cursor-pointer'>
            {billingForm.returnPolicyLabel}
          </AccordionTrigger>
          <AccordionContent className='flex flex-col gap-4'>
            <p>{billingForm.returnPolicyText}</p>
          </AccordionContent>
        </AccordionItem>
      </Accordion>
    </FormProvider>
  );
}
