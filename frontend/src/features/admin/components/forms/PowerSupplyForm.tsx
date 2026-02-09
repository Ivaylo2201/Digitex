import type { PowerSupply } from '@/features/products/models/PowerSupply';
import { useBrands } from '../../hooks/useBrands';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { useProductCreate } from '../../hooks/useProductCreate';
import { useProductUpdate } from '../../hooks/useProductUpdate';
import { Controller, FormProvider, useForm } from 'react-hook-form';
import type { PowerSupplyFormData } from '../../types/PowerSupplyFormData';
import { toast } from 'sonner';
import { BaseForm } from './BaseForm';
import { Label } from '@/components/ui/label';
import { Input } from '@/components/ui/input';
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';
import { usePowerSupplyFormSchema } from '../../hooks/schemas/usePowerSupplyFormSchema';

type PowerSupplyFormProps = {
  product?: PowerSupply;
};

export function PowerSupplyForm({ product }: PowerSupplyFormProps) {
  const { data: brands } = useBrands();
  const {
    components: { powerSupplyForm },
  } = useTranslation();
  const { mutate: onUpdate } = useProductUpdate('power-supplies', product?.id);
  const { mutate: onCreate } = useProductCreate('power-supplies');
  const powerSupplyFormSchema = usePowerSupplyFormSchema();
  const methods = useForm<PowerSupplyFormData>({
    defaultValues: {
      id: product?.id,
      brandId: brands?.find((b) => b.brandName === product?.brandName)?.id,
      modelName: product?.modelName,
      image: {} as FileList,
      price: product?.price.initial,
      discountPercentage: product?.discountPercentage,
      quantity: product?.quantity,
      wattage: product?.wattage,
      formFactor: product?.formFactor,
      efficiencyPercentage: product?.efficiencyPercentage,
      modularity: product?.modularity,
    },
  });

  const onSubmit = async (data: PowerSupplyFormData) => {
    console.log(data);
    const validationResult = powerSupplyFormSchema.safeParse(data);

    if (!validationResult.success) {
      toast.error(validationResult.error.errors[0].message);
      return;
    }

    const formData = new FormData();

    if (data.image?.length) {
      formData.append('Image', data.image[0]);
    }

    formData.append('Id', data.id?.toString());
    formData.append('BrandId', data.brandId.toString());
    formData.append('ModelName', data.modelName);
    formData.append('Price', data.price.toString());
    formData.append('DiscountPercentage', data.discountPercentage.toString());
    formData.append('Quantity', data.quantity.toString());
    formData.append('Wattage', data.wattage.toString());
    formData.append('FormFactor', data.formFactor.toString());
    formData.append(
      'EfficiencyPercentage',
      data.efficiencyPercentage.toString(),
    );
    formData.append('Modularity', data.modularity.toString());

    if (data.id === undefined) {
      onCreate(formData);
    } else {
      onUpdate(formData);
    }
  };

  return (
    <FormProvider {...methods}>
      <BaseForm onSubmit={onSubmit} product={product}>
        <div className='space-y-4'>
          <div className='space-y-2'>
            <Label>{powerSupplyForm.formFactor}</Label>

            <Controller
              control={methods.control}
              name='formFactor'
              render={({ field }) => (
                <Select value={field.value} onValueChange={field.onChange}>
                  <SelectTrigger className='w-full'>
                    <SelectValue />
                  </SelectTrigger>

                  <SelectContent>
                    <SelectItem value='ATX'>ATX</SelectItem>
                    <SelectItem value='Micro ATX'>Micro ATX</SelectItem>
                    <SelectItem value='Mini ITX'>Mini ITX</SelectItem>
                  </SelectContent>
                </Select>
              )}
            />
          </div>

          <div className='space-y-2'>
            <Label>{powerSupplyForm.modularity}</Label>

            <Controller
              control={methods.control}
              name='modularity'
              render={({ field }) => (
                <Select value={field.value} onValueChange={field.onChange}>
                  <SelectTrigger className='w-full'>
                    <SelectValue />
                  </SelectTrigger>

                  <SelectContent>
                    <SelectItem value='Full'>Full</SelectItem>
                    <SelectItem value='Semi'>Semi</SelectItem>
                    <SelectItem value='None'>None</SelectItem>
                  </SelectContent>
                </Select>
              )}
            />
          </div>

          <div className='space-y-2'>
            <Label>{powerSupplyForm.wattage}</Label>
            <Input
              type='number'
              step='any'
              {...methods.register('wattage', { valueAsNumber: true })}
            />
          </div>

          <div className='space-y-2'>
            <Label>{powerSupplyForm.efficiencyPercentage}</Label>
            <Input
              type='number'
              step='any'
              {...methods.register('efficiencyPercentage', {
                valueAsNumber: true,
              })}
            />
          </div>
        </div>
      </BaseForm>
    </FormProvider>
  );
}
