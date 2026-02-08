import type { Monitor } from '@/features/products/models/Monitor';
import { useBrands } from '../../hooks/useBrands';
import { useProductUpdate } from '../../hooks/useProductUpdate';
import { useProductCreate } from '../../hooks/useProductCreate';
import type { MonitorFormData } from '../../types/MonitorFormData';
import { Controller, FormProvider, useForm } from 'react-hook-form';
import { toast } from 'sonner';
import { BaseForm } from './BaseForm';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { useMonitorFormSchema } from '../../hooks/schemas/useMonitorFormSchema';
import { Label } from '@/components/ui/label';
import { Input } from '@/components/ui/input';
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';

type MonitorFormProps = {
  product?: Monitor;
};

export function MonitorForm({ product }: MonitorFormProps) {
  const { data: brands } = useBrands();
  const {
    components: { monitorForm },
  } = useTranslation();
  const { mutate: onUpdate } = useProductUpdate('monitors', product?.id);
  const { mutate: onCreate } = useProductCreate('monitors');
  const monitorFormSchema = useMonitorFormSchema();

  const methods = useForm<MonitorFormData>({
    defaultValues: {
      id: product?.id,
      brandId: brands?.find((b) => b.brandName === product?.brandName)?.id,
      modelName: product?.modelName,
      image: {} as FileList,
      price: product?.price.initial,
      discountPercentage: product?.discountPercentage,
      quantity: product?.quantity,
      displayDiagonal: product?.displayDiagonal,
      refreshRate: product?.refreshRate,
      latency: product?.latency,
      matrix: product?.matrix,
      resolution: product?.resolution,
      pixelSize: product?.pixelSize,
      brightness: product?.brightness,
      colorSpectre: product?.colorSpectre,
    },
  });

  const onSubmit = async (data: MonitorFormData) => {
    console.log(data);
    const validationResult = monitorFormSchema.safeParse(data);

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
    formData.append('DisplayDiagonal', data.displayDiagonal.toString());
    formData.append('RefreshRate', data.refreshRate.toString());
    formData.append('Latency', data.latency.toString());
    formData.append('Matrix', data.matrix.toString());
    formData.append('PixelSize', data.pixelSize.toString());
    formData.append('ColorSpectre', data.colorSpectre.toString());
    formData.append('Resolution.Height', data.resolution.height.toString());
    formData.append('Resolution.Width', data.resolution.width.toString());
    formData.append(
      'Resolution.Type',
      data.resolution.type.toLowerCase() === 'full hd' ? 'FullHd' : 'QuadHd',
    );
    formData.append('Brightness', data.brightness.toString());

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
            <Label>{monitorForm.displayDiagonal} ('')</Label>
            <Input
              type='number'
              step='any'
              {...methods.register('displayDiagonal', { valueAsNumber: true })}
            />
          </div>
          <div className='space-y-2'>
            <Label>
              {monitorForm.refreshRate} {}
            </Label>
            <Input
              type='number'
              step='any'
              {...methods.register('refreshRate', { valueAsNumber: true })}
            />
          </div>
          <div className='space-y-2'>
            <Label>{monitorForm.latency}</Label>
            <Input
              type='number'
              step='any'
              {...methods.register('latency', { valueAsNumber: true })}
            />
          </div>
          <div className='space-y-2'>
            <Label>{monitorForm.matrix}</Label>

            <Controller
              control={methods.control}
              name='matrix'
              render={({ field }) => (
                <Select value={field.value} onValueChange={field.onChange}>
                  <SelectTrigger className='w-full'>
                    <SelectValue />
                  </SelectTrigger>

                  <SelectContent>
                    <SelectItem value='IPS'>IPS</SelectItem>
                    <SelectItem value='VA'>VA</SelectItem>
                    <SelectItem value='TN'>TN</SelectItem>
                  </SelectContent>
                </Select>
              )}
            />
          </div>
          <div className='space-y-2'>
            <Label>{monitorForm.resolution.height}</Label>
            <Input
              type='number'
              step='any'
              {...methods.register('resolution.height', {
                valueAsNumber: true,
              })}
            />
          </div>
          <div className='space-y-2'>
            <Label>{monitorForm.resolution.width}</Label>
            <Input
              type='number'
              step='any'
              {...methods.register('resolution.width', { valueAsNumber: true })}
            />
          </div>
          <div className='space-y-2'>
            <Label>{monitorForm.resolution.type}</Label>

            <Controller
              control={methods.control}
              name='resolution.type'
              render={({ field }) => (
                <Select value={field.value} onValueChange={field.onChange}>
                  <SelectTrigger className='w-full'>
                    <SelectValue />
                  </SelectTrigger>

                  <SelectContent>
                    <SelectItem value='Full HD'>Full HD</SelectItem>
                    <SelectItem value='Quad HD'>Quad HD</SelectItem>
                  </SelectContent>
                </Select>
              )}
            />
          </div>
          <div className='space-y-2'>
            <Label>{monitorForm.pixelSize}</Label>
            <Input
              type='number'
              step='any'
              {...methods.register('pixelSize', { valueAsNumber: true })}
            />
          </div>
          <div className='space-y-2'>
            <Label>{monitorForm.brightness}</Label>
            <Input
              type='number'
              step='any'
              {...methods.register('brightness', { valueAsNumber: true })}
            />
          </div>
          <div className='space-y-2'>
            <Label>{monitorForm.colorSpectre}</Label>
            <Input
              type='number'
              step='any'
              {...methods.register('colorSpectre', { valueAsNumber: true })}
            />
          </div>
        </div>
      </BaseForm>
    </FormProvider>
  );
}
