import type { Motherboard } from '@/features/products/models/Motherboard';
import { Controller, FormProvider, useForm } from 'react-hook-form';
import { BaseForm } from './BaseForm';
import { useBrands } from '../../hooks/useBrands';
import { useProductUpdate } from '../../hooks/useProductUpdate';
import type { MotherboardFormData } from '../../types/MotherboardFormData';
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
import { useMotherboardFormSchema } from '../../hooks/schemas/useMotherboardFormSchema';
import { useProductCreate } from '../../hooks/useProductCreate';

type MotherboardFormProps = {
  product?: Motherboard;
};

export function MotherboardForm({ product }: MotherboardFormProps) {
  const { data: brands } = useBrands();
  const {
    components: { motherboardForm },
  } = useTranslation();
  const { mutate: onUpdate } = useProductUpdate('motherboards', product?.id);
  const { mutate: onCreate } = useProductCreate('motherboards');
  const motherboardFormSchema = useMotherboardFormSchema();
  const methods = useForm<MotherboardFormData>({
    defaultValues: {
      id: product?.id,
      brandId: brands?.find((b) => b.brandName === product?.brandName)?.id,
      modelName: product?.modelName,
      image: {} as FileList,
      price: product?.price.initial,
      discountPercentage: product?.discountPercentage,
      quantity: product?.quantity,
      socket: product?.socket,
      formFactor: product?.formFactor
        .split(' ')
        .map(
          (word) => word.charAt(0).toUpperCase() + word.slice(1).toLowerCase(),
        )
        .join(''),
      chipset: product?.chipset,
      ramSlots: product?.ramSlots,
      pcieSlots: product?.pcieSlots,
    },
  });

  const onSubmit = async (data: MotherboardFormData) => {
    console.log(data);
    const validationResult = motherboardFormSchema.safeParse(data);

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
    formData.append('FormFactor', data.formFactor);
    formData.append('Chipset', data.chipset);
    formData.append('RamSlots', data.ramSlots.toString());
    formData.append('PcieSlots', data.pcieSlots.toString());

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
            <Label>{motherboardForm.socket}</Label>

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
            <Label>{motherboardForm.formFactor}</Label>

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
            <Label>{motherboardForm.chipset}</Label>

            <Controller
              control={methods.control}
              name='chipset'
              render={({ field }) => (
                <Select value={field.value} onValueChange={field.onChange}>
                  <SelectTrigger className='w-full'>
                    <SelectValue />
                  </SelectTrigger>

                  <SelectContent>
                    <SelectItem value='A620'>A620</SelectItem>
                    <SelectItem value='B550'>B550</SelectItem>
                    <SelectItem value='B650'>B650</SelectItem>
                    <SelectItem value='B760'>B760</SelectItem>
                    <SelectItem value='B840'>B840</SelectItem>
                    <SelectItem value='B850'>B850</SelectItem>
                    <SelectItem value='B860'>B860</SelectItem>
                  </SelectContent>
                </Select>
              )}
            />
          </div>

          <div className='space-y-2'>
            <Label>{motherboardForm.ramSlots}</Label>
            <Input
              type='number'
              step='any'
              {...methods.register('ramSlots', { valueAsNumber: true })}
            />
          </div>

          <div className='space-y-2'>
            <Label>{motherboardForm.pcieSlots}</Label>
            <Input
              type='number'
              step='any'
              {...methods.register('pcieSlots', { valueAsNumber: true })}
            />
          </div>
        </div>
      </BaseForm>
    </FormProvider>
  );
}
