import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';
import type { Ssd } from '@/features/products/models/Ssd';
import { useBrands } from '../../hooks/useBrands';
import { useProductUpdate } from '../../hooks/useProductUpdate';
import { useProductCreate } from '../../hooks/useProductCreate';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { Controller, FormProvider, useForm } from 'react-hook-form';
import type { SsdFormData } from '../../types/SsdFormData';
import { toast } from 'sonner';
import { BaseForm } from './BaseForm';
import { useSsdFormSchema } from '../../hooks/schemas/useSsdFormSchema';
import { Label } from '@/components/ui/label';
import { Input } from '@/components/ui/input';

type SsdFormProps = {
  product?: Ssd;
};

function convertStorageInterface(storageInterface: string) {
  const interfaces = {
    SATA: 'Sata',
    NVMe: 'Nvme',
    'PCIe 4.0': 'Pcie4',
    'PCIe 5.0': 'Pcie5',
  };

  return (
    interfaces[storageInterface as keyof typeof interfaces] || storageInterface
  );
}

export function SsdForm({ product }: SsdFormProps) {
  const { data: brands } = useBrands();
  const { mutate: onUpdate } = useProductUpdate('ssds', product?.id);
  const { mutate: onCreate } = useProductCreate('ssds');
  const {
    components: { ssdForm },
  } = useTranslation();
  const ssdFormSchema = useSsdFormSchema();
  const methods = useForm<SsdFormData>({
    defaultValues: {
      id: product?.id,
      brandId: brands?.find((b) => b.brandName === product?.brandName)?.id,
      modelName: product?.modelName,
      image: {} as FileList,
      price: product?.price.initial,
      discountPercentage: product?.discountPercentage,
      quantity: product?.quantity,
      capacityInGb: product?.capacityInGb,
      operationSpeed: product?.operationSpeed,
      storageInterface: product?.storageInterface,
    },
  });

  const onSubmit = async (data: SsdFormData) => {
    console.log(data);
    const validationResult = ssdFormSchema.safeParse(data);

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
    formData.append('CapacityInGb', data.capacityInGb.toString());
    formData.append('OperationSpeed.Read', data.operationSpeed.read.toString());
    formData.append(
      'OperationSpeed.Write',
      data.operationSpeed.write.toString(),
    );
    formData.append('StorageInterface', convertStorageInterface(data.storageInterface));

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
            <Label>{ssdForm.capacityInGb}</Label>
            <Input
              type='number'
              {...methods.register('capacityInGb', { valueAsNumber: true })}
            />
          </div>
          <div className='space-y-2'>
            <Label>{ssdForm.operationSpeed.read}</Label>
            <Input
              type='number'
              {...methods.register('operationSpeed.read', {
                valueAsNumber: true,
              })}
            />
          </div>
          <div className='space-y-2'>
            <Label>{ssdForm.operationSpeed.write}</Label>
            <Input
              type='number'
              {...methods.register('operationSpeed.write', {
                valueAsNumber: true,
              })}
            />
          </div>
          <div className='space-y-2'>
            <Label>{ssdForm.storageInterface}</Label>

            <Controller
              control={methods.control}
              name='storageInterface'
              render={({ field }) => (
                <Select value={field.value} onValueChange={field.onChange}>
                  <SelectTrigger className='w-full'>
                    <SelectValue />
                  </SelectTrigger>

                  <SelectContent>
                    <SelectItem value='SATA'>SATA</SelectItem>
                    <SelectItem value='NVMe'>NVMe</SelectItem>
                    <SelectItem value='PCIe 4.0'>PCIe 4.0</SelectItem>
                    <SelectItem value='PCIe 5.0'>PCIe 5.0</SelectItem>
                  </SelectContent>
                </Select>
              )}
            />
          </div>
        </div>
      </BaseForm>
    </FormProvider>
  );
}
