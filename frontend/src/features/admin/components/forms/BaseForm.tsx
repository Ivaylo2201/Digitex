import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from '@/components/ui/dialog';
import { Button } from '@/components/ui/button';
import { useState, type PropsWithChildren } from 'react';
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';
import { Input } from '@/components/ui/input';
import { Controller, useFormContext } from 'react-hook-form';
import { useBrands } from '../../hooks/useBrands';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import { SquarePen } from 'lucide-react';
import type { BaseFormData } from '../../types/BaseFormData';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { Label } from '@/components/ui/label';

type BaseFormProps<T extends { imagePath: string; sku: string }> =
  PropsWithChildren & {
    product?: T;
    onSubmit: (data: any) => Promise<void>;
  };

export function BaseForm<T extends { imagePath: string; sku: string }>({
  product,
  onSubmit,
  children,
}: BaseFormProps<T>) {
  const [open, setOpen] = useState(false);
  const { register, control, handleSubmit } = useFormContext<BaseFormData>();
  const { data: brands } = useBrands();
  const {
    components: { baseForm },
  } = useTranslation();

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        {product ? (
          <SquarePen className='h-4 w-4 cursor-pointer' />
        ) : (
          <Button
            variant='secondary'
            className='bg-theme-crimson text-theme-white hover:bg-theme-gunmetal hover:text-theme-white cursor-pointer'
          >
            {baseForm.add}
          </Button>
        )}
      </DialogTrigger>

      <DialogContent className='sm:max-w-4xl'>
        <DialogHeader>
          <DialogTitle>
            {product ? baseForm.editingProduct : baseForm.addNewProduct}{' '}
            {product?.sku}
          </DialogTitle>
          <DialogDescription>{baseForm.fillInDetails}</DialogDescription>
        </DialogHeader>
        <form
          className='grid grid-cols-2 gap-6'
          onSubmit={handleSubmit(onSubmit)}
        >
          <div className='space-y-4'>
            <Controller
              control={control}
              name='brandId'
              render={({ field }) => (
                <div className='space-y-2'>
                  <Label>{baseForm.brand}</Label>
                  <Select
                    value={field.value?.toString() || ''}
                    onValueChange={(val) => field.onChange(Number(val))}
                  >
                    <SelectTrigger className='w-full'>
                      <SelectValue />
                    </SelectTrigger>
                    <SelectContent>
                      {brands?.map((brand) => (
                        <SelectItem key={brand.id} value={brand.id.toString()}>
                          {brand.brandName}
                        </SelectItem>
                      ))}
                    </SelectContent>
                  </Select>
                </div>
              )}
            />

            <div className='space-y-2'>
              <Label>{baseForm.modelName}</Label>
              <Input {...register('modelName')} />
            </div>

            {product?.imagePath && (
              <div className='relative w-32 h-32 mb-2 border rounded-md overflow-hidden'>
                <img
                  src={getStaticFile(product?.imagePath || '')}
                  alt='Current product'
                  className='object-cover w-full h-full'
                />
                <span className='absolute bottom-0 w-full bg-black/50 text-white text-[10px] text-center'>
                  {baseForm.currentImage}
                </span>
              </div>
            )}

            <div className='space-y-2'>
              <Label>{baseForm.image}</Label>
              <Input {...register('image')} type='file' accept='image/*' />
            </div>

            <div className='grid grid-cols-2 gap-4'>
              <div className='space-y-2'>
                <Label>{baseForm.price}</Label>
                <Input
                  {...register('price', { valueAsNumber: true })}
                  type='number'
                />
              </div>

              <div className='space-y-2'>
                <Label>{baseForm.discountPercentage}</Label>
                <Input
                  {...register('discountPercentage', { valueAsNumber: true })}
                  type='number'
                />
              </div>

              <div className='space-y-2'>
                <Label>{baseForm.quantity}</Label>
                <Input
                  {...register('quantity', { valueAsNumber: true })}
                  type='number'
                />
              </div>
            </div>
          </div>

          <div className='space-y-4'>{children}</div>

          <div className='col-span-2 flex justify-end gap-2 mt-4'>
            <Button
              className='cursor-pointer bg-theme-gunmetal text-white'
              type='button'
              onClick={() => setOpen(false)}
            >
              {baseForm.cancel}
            </Button>
            <Button className='cursor-pointer bg-theme-crimson' type='submit'>
              {baseForm.save}
            </Button>
          </div>
        </form>
      </DialogContent>
    </Dialog>
  );
}
