import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table';
import {
  flexRender,
  getCoreRowModel,
  getFilteredRowModel,
  getPaginationRowModel,
  getSortedRowModel,
  useReactTable,
  type ColumnDef,
  type ColumnFiltersState,
  type SortingState,
  type VisibilityState,
} from '@tanstack/react-table';
import { ArrowUpDown, SquarePen, Trash } from 'lucide-react';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import { useState } from 'react';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from '@/components/ui/dialog';
import { useCurrencyStore } from '@/features/currency/stores/useCurrencyStore';

function getColumns<T extends ProductLong>(
  columns: ColumnDef<T>[],
  sign: string,
  onDelete: (id: string) => void,
) {
  const baseColumns: ColumnDef<T>[] = [
    {
      accessorKey: 'sku',
      header: 'SKU',
      cell: ({ row }) => <span>{row.getValue('sku')}</span>,
    },
    {
      id: 'product',
      header: 'Product',
      cell: ({ row }) => {
        const { brandName, modelName, imagePath } = row.original;

        return (
          <div className='flex items-center gap-3 max-w-96'>
            <img
              src={getStaticFile(imagePath)}
              alt={modelName}
              className='h-12 w-12 rounded object-contain'
            />
            <div className='leading-tight overflow-hidden'>
              <div className='font-medium'>{brandName}</div>
              <div className='text-sm text-muted-foreground truncate'>
                {modelName}
              </div>
            </div>
          </div>
        );
      },
    },
    {
      accessorKey: 'discountPercentage',
      header: ({ column }) => (
        <Button
          variant='ghost'
          className='text-right'
          onClick={() => column.toggleSorting(column.getIsSorted() === 'asc')}
        >
          Discount Percentage
          <ArrowUpDown className='ml-1 h-4 w-4' />
        </Button>
      ),
      cell: ({ row }) => <span>{row.original.discountPercentage} %</span>,
    },
    {
      id: 'price',
      header: ({ column }) => (
        <Button
          variant='ghost'
          className='text-right'
          onClick={() => column.toggleSorting(column.getIsSorted() === 'asc')}
        >
          Price
          <ArrowUpDown className='ml-1 h-4 w-4' />
        </Button>
      ),
      accessorFn: (row) => row.price.initial,
      cell: ({ row }) => {
        const { initial, discounted } = row.original.price;

        return (
          <span className='font-medium'>
            {sign}
            {initial.toFixed(2)}
            {initial !== discounted && ` (${sign}${discounted.toFixed(2)})`}
          </span>
        );
      },
    },
    {
      accessorKey: 'quantity',
      header: ({ column }) => (
        <Button
          variant='ghost'
          className='text-right'
          onClick={() => column.toggleSorting(column.getIsSorted() === 'asc')}
        >
          Quantity
          <ArrowUpDown className='ml-1 h-4 w-4' />
        </Button>
      ),
    },
  ];

  const actionsColumn: ColumnDef<T> = {
    id: 'actions',
    enableHiding: false,
    cell: ({ row }) => (
      <div className='flex items-center gap-3'>
        <Dialog>
          <DialogTrigger asChild>
            <button
              className='h-4 w-4 p-0 text-destructive hover:opacity-80'
              aria-label='Delete product'
            >
              <Trash className='h-4 w-4' />
            </button>
          </DialogTrigger>

          <DialogContent>
            <DialogHeader>
              <DialogTitle>Confirm Deletion</DialogTitle>
              <DialogDescription>
                Are you sure you want to delete{' '}
                <strong>{row.original.modelName}</strong>?
              </DialogDescription>
            </DialogHeader>

            <DialogFooter className='flex justify-end gap-2'>
              <Button variant='outline'>Cancel</Button>
              <Button
                variant='destructive'
                onClick={() => onDelete(row.original.id)}
              >
                Delete
              </Button>
            </DialogFooter>
          </DialogContent>
        </Dialog>

        <SquarePen className='h-4 w-4 cursor-pointer hover:text-foreground' />
      </div>
    ),
  };

  return [...baseColumns, ...columns, actionsColumn] as ColumnDef<T>[];
}

type DatatableProps<T extends ProductLong> = {
  data: T[];
  columns: ColumnDef<T>[];
  onDelete: (id: string) => void;
};

export function DataTable<T extends ProductLong>({
  data,
  columns,
  onDelete,
}: DatatableProps<T>) {
  const [sorting, setSorting] = useState<SortingState>([]);
  const [columnFilters, setColumnFilters] = useState<ColumnFiltersState>([]);
  const [columnVisibility, setColumnVisibility] = useState<VisibilityState>({});
  const [rowSelection, setRowSelection] = useState({});

  const {} = useTranslation();
  const sign = useCurrencyStore((state) => state.currency.sign);

  const table = useReactTable({
    data,
    columns: getColumns(columns, sign, onDelete),
    onSortingChange: setSorting,
    onColumnFiltersChange: setColumnFilters,
    getCoreRowModel: getCoreRowModel(),
    getPaginationRowModel: getPaginationRowModel(),
    getSortedRowModel: getSortedRowModel(),
    getFilteredRowModel: getFilteredRowModel(),
    onColumnVisibilityChange: setColumnVisibility,
    onRowSelectionChange: setRowSelection,
    state: {
      sorting,
      columnFilters,
      columnVisibility,
      rowSelection,
    },
  });

  return (
    <div className='w-full'>
      <div className='flex items-center py-4'>
        <Input
          placeholder='Find by SKU'
          value={(table.getColumn('sku')?.getFilterValue() as string) ?? ''}
          onChange={(event) =>
            table.getColumn('sku')?.setFilterValue(event.target.value)
          }
          className='max-w-sm'
        />
      </div>
      <div className='overflow-hidden rounded-md border'>
        <Table>
          <TableHeader>
            {table.getHeaderGroups().map((headerGroup) => (
              <TableRow key={headerGroup.id}>
                {headerGroup.headers.map((header) => {
                  return (
                    <TableHead
                      key={header.id}
                      className='bg-theme-gunmetal text-white'
                    >
                      {header.isPlaceholder
                        ? null
                        : flexRender(
                            header.column.columnDef.header,
                            header.getContext(),
                          )}
                    </TableHead>
                  );
                })}
              </TableRow>
            ))}
          </TableHeader>
          <TableBody>
            {table.getRowModel().rows?.length ? (
              table.getRowModel().rows.map((row) => (
                <TableRow
                  key={row.id}
                  data-state={row.getIsSelected() && 'selected'}
                >
                  {row.getVisibleCells().map((cell) => (
                    <TableCell key={cell.id}>
                      {flexRender(
                        cell.column.columnDef.cell,
                        cell.getContext(),
                      )}
                    </TableCell>
                  ))}
                </TableRow>
              ))
            ) : (
              <TableRow>
                <TableCell
                  colSpan={columns.length}
                  className='h-24 text-center'
                >
                  No results.
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </div>
      <div className='flex items-center justify-end space-x-2 py-4'>
        <div className='space-x-2'>
          <Button
            variant='outline'
            size='sm'
            onClick={() => table.previousPage()}
            disabled={!table.getCanPreviousPage()}
          >
            Previous
          </Button>
          <Button
            variant='outline'
            size='sm'
            onClick={() => table.nextPage()}
            disabled={!table.getCanNextPage()}
          >
            Next
          </Button>
        </div>
      </div>
    </div>
  );
}
