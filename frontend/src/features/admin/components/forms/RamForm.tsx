import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';
import type { Ram } from '@/features/products/models/Ram';
import { useBrands } from '../../hooks/useBrands';
import { useProductUpdate } from '../../hooks/useProductUpdate';
import { useProductCreate } from '../../hooks/useProductCreate';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import type { RamFormData } from '../../types/RamFormData';
import { Controller, FormProvider, useForm } from 'react-hook-form';
import { toast } from 'sonner';
import { BaseForm } from './BaseForm';
import { Label } from '@/components/ui/label';
import { Input } from '@/components/ui/input';
import { useRamFormSchema } from '../../hooks/schemas/useRamFormSchema';

type RamFormProps = {
  product?: Ram;
};

export function RamForm({ product }: RamFormProps) {
  const { data: brands } = useBrands();
  const { mutate: onUpdate } = useProductUpdate('rams', product?.id);
  const { mutate: onCreate } = useProductCreate('rams');
  const {
    components: { ramForm },
  } = useTranslation();
  const ramFormSchema = useRamFormSchema();
  const methods = useForm<RamFormData>({
    defaultValues: {
      id: product?.id,
      brandId: brands?.find((b) => b.brandName === product?.brandName)?.id,
      modelName: product?.modelName,
      image: {} as FileList,
      price: product?.price.initial,
      discountPercentage: product?.discountPercentage,
      quantity: product?.quantity,
      memory: product?.memory,
      timing: product?.timing,
    },
  });

  const onSubmit = async (data: RamFormData) => {
    console.log(data);
    const validationResult = ramFormSchema.safeParse(data);

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
    formData.append('Memory.CapacityInGb', data.memory.capacityInGb.toString());
    formData.append('Memory.Frequency', data.memory.frequency.toString());
    formData.append('Memory.Type', data.memory.type);
    formData.append('Timing', data.timing);

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
            <Label>{ramForm.memory.capacityInGb}</Label>
            <Input
              type='number'
              {...methods.register('memory.capacityInGb', {
                valueAsNumber: true,
              })}
            />
          </div>

          <div className='space-y-2'>
            <Label>{ramForm.memory.type}</Label>

            <Controller
              control={methods.control}
              name='memory.type'
              render={({ field }) => (
                <Select value={field.value} onValueChange={field.onChange}>
                  <SelectTrigger className='w-full'>
                    <SelectValue />
                  </SelectTrigger>

                  <SelectContent>
                    <SelectItem value='DDR4'>DDR4</SelectItem>
                    <SelectItem value='DDR5'>DDR5</SelectItem>
                    <SelectItem value='GDDR5'>GDDR5</SelectItem>
                    <SelectItem value='GDDR6'>GDDR6</SelectItem>
                    <SelectItem value='GDDR7'>GDDR7</SelectItem>
                  </SelectContent>
                </Select>
              )}
            />
          </div>

          <div className='space-y-2'>
            <Label>{ramForm.memory.frequency}</Label>
            <Input
              type='number'
              {...methods.register('memory.frequency', { valueAsNumber: true })}
            />
          </div>

          <div className='space-y-2'>
            <Label>{ramForm.timing}</Label>
            <Input type='text' {...methods.register('timing')} />
          </div>
        </div>
      </BaseForm>
    </FormProvider>
  );
}
