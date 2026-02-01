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
import type { ProductUpsert } from '../../types/ProductUpsert';
import { useBrands } from '../../hooks/useBrands';

type UpsertFormProps<T> = PropsWithChildren & {
  product?: T;
  onSubmit: (data: any) => Promise<void>;
};

export function UpsertForm<T>({ onSubmit, children }: UpsertFormProps<T>) {
  const [open, setOpen] = useState(false);
  const { register, control, handleSubmit } = useFormContext<ProductUpsert>();
  const { data: brands } = useBrands();

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <Button
          variant='secondary'
          className='bg-theme-gunmetal text-theme-white hover:bg-theme-gunmetal hover:text-theme-white'
        >
          Add
        </Button>
      </DialogTrigger>

      <DialogContent className='sm:max-w-4xl'>
        <DialogHeader>
          <DialogTitle>Add New Product</DialogTitle>
          <DialogDescription>
            Fill in the details to create a new product.
          </DialogDescription>
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
                <Select
                  value={field.value?.toString() || ''}
                  onValueChange={(val) => field.onChange(Number(val))}
                >
                  <SelectTrigger>
                    <SelectValue placeholder='Brand' />
                  </SelectTrigger>
                  <SelectContent>
                    {brands?.map((brand) => (
                      <SelectItem key={brand.id} value={brand.id.toString()}>
                        {brand.brandName}
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
              )}
            />

            <Input {...register('modelName')} placeholder='Model Name' />

            <Input {...register('image')} type='file' accept='image/*' />

            <div className='grid grid-cols-2 gap-4'>
              <Input
                {...register('price', { valueAsNumber: true })}
                type='number'
                placeholder='Price'
              />
              <Input
                {...register('discountPercentage', { valueAsNumber: true })}
                type='number'
                placeholder='Discount (%)'
              />
              <Input
                {...register('quantity', { valueAsNumber: true })}
                type='number'
                placeholder='Quantity'
              />
            </div>
          </div>

          <div className='space-y-4'>{children}</div>

          <div className='col-span-2 flex justify-end gap-2 mt-4'>
            <Button
              variant='outline'
              type='button'
              onClick={() => setOpen(false)}
            >
              Cancel
            </Button>
            <Button type='submit'>Save</Button>
          </div>
        </form>
      </DialogContent>
    </Dialog>
  );
}
