import { Button } from '@/components/ui/button';
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from '@/components/ui/dialog';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import type { ProductShort } from '@/features/products/models/base/ProductShort';
import { useQueryClient } from '@tanstack/react-query';
import type { Row } from '@tanstack/react-table';
import { Trash } from 'lucide-react';
import { useState } from 'react';

type DeleteProductDialogProps<T extends ProductShort> = {
  row: Row<T>;
  onDelete: (id: string) => void;
};

export function DeleteProductDialog<T extends ProductShort>({
  row,
  onDelete,
}: DeleteProductDialogProps<T>) {
  const [open, setOpen] = useState(false);
  const queryClient = useQueryClient();
  const {
    components: { dataTable },
  } = useTranslation();

  const handleDelete = async (id: string) => {
    onDelete(id);
    queryClient.invalidateQueries({
      queryKey: ['product', row.original.id],
    });
    setOpen(false);
  };

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <button
          className='h-4 w-4 p-0 text-destructive hover:opacity-80 cursor-pointer'
          aria-label='Delete product'
        >
          <Trash className='h-4 w-4' />
        </button>
      </DialogTrigger>

      <DialogContent>
        <DialogHeader>
          <DialogTitle>{dataTable.confirmDeletion}</DialogTitle>
          <DialogDescription>
            {dataTable.areYouSureYouWantToDelete}{' '}
            <strong className='text-theme-gunmetal'>
              {row.original.modelName}
            </strong>
          </DialogDescription>
        </DialogHeader>

        <DialogFooter className='flex justify-end gap-2'>
          <Button
            className='cursor-pointer bg-theme-gunmetal text-white'
            onClick={() => setOpen(false)}
          >
            {dataTable.cancel}
          </Button>
          <Button
            variant='destructive'
            className='cursor-pointer bg-theme-crimson'
            onClick={() => handleDelete(row.original.id)}
          >
            {dataTable.delete}
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}
