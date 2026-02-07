import { Controller, FormProvider, useForm } from 'react-hook-form';
import { BaseForm } from './BaseForm';
import { useBrands } from '../../hooks/useBrands';
import { useProductUpdate } from '../../hooks/useProductUpdate';
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';
import { Label } from '@/components/ui/label';
import { Input } from '@/components/ui/input';
import { toast } from 'sonner';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import type { Processor } from '@/features/products/models/Processor';
import { useProcessorFormSchema } from '../../hooks/schemas/useProcessorFormSchema';
import type { ProcessorFormData } from '../../types/ProcessorFormData';
import { useProductCreate } from '../../hooks/useProductCreate';

type ProcessorFormProps = {
  product?: Processor;
};

export function ProcessorForm({ product }: ProcessorFormProps) {
  const { data: brands } = useBrands();
  const { mutate: onUpdate } = useProductUpdate('processors', product?.id);
  const { mutate: onCreate } = useProductCreate('processors');
  const {
    components: { processorForm },
  } = useTranslation();
  const processorFormSchema = useProcessorFormSchema();
  const methods = useForm<ProcessorFormData>({
    defaultValues: {
      id: product?.id,
      brandId: brands?.find((b) => b.brandName === product?.brandName)?.id,
      modelName: product?.modelName,
      image: {} as FileList,
      price: product?.price.initial,
      discountPercentage: product?.discountPercentage,
      quantity: product?.quantity,
      cores: product?.cores,
      threads: product?.threads,
      clockSpeed: {
        base: product?.clockSpeed.base,
        boost: product?.clockSpeed.boost,
      },
      socket: product?.socket,
      tdp: product?.tdp,
    },
  });

  const onSubmit = async (data: ProcessorFormData) => {
    console.log(data);
    const validationResult = processorFormSchema.safeParse(data);

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
    formData.append('Socket', data.socket);
    formData.append('Cores', data.cores.toString());
    formData.append('Threads', data.threads.toString());
    formData.append('Tdp', data.tdp.toString());
    formData.append('ClockSpeed.Base', data.clockSpeed.base.toString());
    formData.append('ClockSpeed.Boost', data.clockSpeed.boost.toString());

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
            <Label>{processorForm.cores}</Label>
            <Input
              type='number'
              step='any'
              {...methods.register('cores', { valueAsNumber: true })}
            />
          </div>
          <div className='space-y-2'>
            <Label>{processorForm.threads}</Label>
            <Input
              type='number'
              step='any'
              {...methods.register('threads', { valueAsNumber: true })}
            />
          </div>
          <div className='space-y-4'>
            <div className='space-y-2'>
              <Label>{processorForm.clockSpeed.base}</Label>
              <Input
                type='number'
                step='any'
                {...methods.register('clockSpeed.base', {
                  valueAsNumber: true,
                })}
              />
            </div>

            <div className='space-y-2'>
              <Label>{processorForm.clockSpeed.boost}</Label>
              <Input
                type='number'
                step='any'
                {...methods.register('clockSpeed.boost', {
                  valueAsNumber: true,
                })}
              />
            </div>

            <div className='space-y-2'>
              <Label>{processorForm.socket}</Label>

              <Controller
                control={methods.control}
                name='socket'
                render={({ field }) => (
                  <Select value={field.value} onValueChange={field.onChange}>
                    <SelectTrigger className='w-full'>
                      <SelectValue />
                    </SelectTrigger>

                    <SelectContent>
                      <SelectItem value='LGA1200'>LGA1200</SelectItem>
                      <SelectItem value='LGA1700'>LGA1700</SelectItem>
                      <SelectItem value='AM4'>AM4</SelectItem>
                      <SelectItem value='AM5'>AM5</SelectItem>
                    </SelectContent>
                  </Select>
                )}
              />
            </div>

            <div className='space-y-2'>
              <Label>{processorForm.tdp}</Label>
              <Input
                type='number'
                {...methods.register('tdp', { valueAsNumber: true })}
              />
            </div>
          </div>
        </div>
      </BaseForm>
    </FormProvider>
  );
}
