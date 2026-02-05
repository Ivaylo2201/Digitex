import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';
import { Input } from '@/components/ui/input';
import { Controller, FormProvider, useForm } from 'react-hook-form';
import { BaseForm } from './BaseForm';
import type { GraphicsCard } from '@/features/products/models/GraphicsCard';
import { useBrands } from '../hooks/useBrands';
import type { GraphicsCardFormData } from '../types/GraphicsCardFormData';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { Label } from '@/components/ui/label';
import { useProductUpdate } from '../hooks/useProductUpdate';

type GraphicsCardFormProps = {
  product?: GraphicsCard;
};

export function GraphicsCardForm({ product }: GraphicsCardFormProps) {
  const { data: brands } = useBrands();
  const {
    components: { graphicsCardForm },
  } = useTranslation();
  const { mutate: onUpdate } = useProductUpdate('graphics-cards', product?.id);

  const methods = useForm<GraphicsCardFormData>({
    defaultValues: {
      id: product?.id,
      brandId: brands?.find((b) => b.brandName === product?.brandName)?.id,
      modelName: product?.modelName,
      image: {} as FileList,
      price: product?.price.initial,
      discountPercentage: product?.discountPercentage,
      quantity: product?.quantity,
      memory: {
        capacityInGb: product?.memory.capacityInGb,
        type: product?.memory.type,
        frequency: product?.memory.frequency,
      },
      clockSpeed: {
        base: product?.clockSpeed.base,
        boost: product?.clockSpeed.boost,
      },
      busWidth: product?.busWidth,
      cudaCores: product?.cudaCores,
      directXSupport: product?.directXSupport,
      tdp: product?.tdp,
    },
  });

  const { register, control } = methods;

  const onSubmit = async (data: GraphicsCardFormData) => {
    console.log(data);
    const formData = new FormData();

    if (data.image?.length) {
      formData.append('ImagePath', data.image[0]);
    }

    formData.append('Id', data.id?.toString());
    formData.append('BrandId', data.brandId.toString());
    formData.append('ModelName', data.modelName);
    formData.append('InitialPrice', data.price.toString());
    formData.append('DiscountPercentage', data.discountPercentage.toString());
    formData.append('Quantity', data.quantity.toString());
    formData.append('BusWidth', data.busWidth.toString());
    formData.append('CudaCores', data.cudaCores.toString());
    formData.append('DirectXSupport', data.directXSupport.toString());
    formData.append('Tdp', data.tdp.toString());
    formData.append('ClockSpeed.Base', data.clockSpeed.base.toString());
    formData.append('ClockSpeed.Boost', data.clockSpeed.boost.toString());
    formData.append('Memory.CapacityInGb', data.memory.capacityInGb.toString());
    formData.append('Memory.Frequency', data.memory.frequency.toString());
    formData.append('Memory.Type', data.memory.type);

    onUpdate(formData);
  };

  return (
    <FormProvider {...methods}>
      <BaseForm onSubmit={onSubmit} product={product}>
        <div className='space-y-4'>
          <div className='space-y-2'>
            <Label>{graphicsCardForm.memory.capacityInGb}</Label>
            <Input
              type='number'
              {...register('memory.capacityInGb', { valueAsNumber: true })}
            />
          </div>

          <div className='space-y-2'>
            <Label>{graphicsCardForm.memory.type}</Label>

            <Controller
              control={control}
              name='memory.type'
              render={({ field }) => (
                <Select value={field.value} onValueChange={field.onChange}>
                  <SelectTrigger className='w-full'>
                    <SelectValue placeholder={graphicsCardForm.chooseAType} />
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
            <Label>{graphicsCardForm.memory.frequency}</Label>
            <Input
              type='number'
              {...register('memory.frequency', { valueAsNumber: true })}
            />
          </div>
        </div>

        <div className='space-y-4'>
          <div className='space-y-2'>
            <Label>{graphicsCardForm.clockSpeed.base}</Label>
            <Input
              type='number'
              step='any'
              {...register('clockSpeed.base', { valueAsNumber: true })}
            />
          </div>

          <div className='space-y-2'>
            <Label>{graphicsCardForm.clockSpeed.boost}</Label>
            <Input
              type='number'
              step='any'
              {...register('clockSpeed.boost', { valueAsNumber: true })}
            />
          </div>
        </div>

        <div className='grid grid-cols-2 gap-4'>
          <div className='space-y-2'>
            <Label>{graphicsCardForm.busWidth}</Label>
            <Input
              type='number'
              {...register('busWidth', { valueAsNumber: true })}
            />
          </div>

          <div className='space-y-2'>
            <Label>{graphicsCardForm.cudaCores}</Label>
            <Input
              type='number'
              {...register('cudaCores', { valueAsNumber: true })}
            />
          </div>

          <div className='space-y-2'>
            <Label>{graphicsCardForm.directXSupport}</Label>
            <Input
              type='number'
              {...register('directXSupport', { valueAsNumber: true })}
            />
          </div>

          <div className='space-y-2'>
            <Label>{graphicsCardForm.tdp}</Label>
            <Input
              type='number'
              {...register('tdp', { valueAsNumber: true })}
            />
          </div>
        </div>
      </BaseForm>
    </FormProvider>
  );
}
