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
import { ArrowUpDown, Minus, Plus, Trash } from 'lucide-react';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import {
  useRef,
  useState,
  type PropsWithChildren,
  type RefObject,
} from 'react';
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
import { type Translation } from '@/features/language/models/Translation';
import { httpClient } from '@/lib/api/httpClient';
import { useQueryClient } from '@tanstack/react-query';

function getColumns<T extends ProductLong>(
  columns: ColumnDef<T>[],
  sign: string,
  onDelete: (id: string) => void,
  renderEditForm: (product: T) => React.ReactNode,
  translation: Translation['components']['dataTable'],
  suggestionSku: RefObject<string>,
) {
  const baseColumns: ColumnDef<T>[] = [
    {
      accessorKey: 'sku',
      header: translation.sku,
      cell: ({ row }) => <span>{row.getValue('sku')}</span>,
    },
    {
      id: 'product',
      header: translation.product,
      cell: ({ row }) => {
        const { brandName, modelName, imagePath } = row.original;

        return (
          <div className='flex items-center gap-3 max-w-96'>
            <img
              src={getStaticFile(imagePath)}
              alt={modelName}
              className='h-12 w-12 rounded object-contain shrink-0'
            />
            <div className='flex flex-col justify-start items-start overflow-hidden min-w-0'>
              <div className='font-medium truncate w-full text-start'>
                {brandName}
              </div>
              <div className='text-sm text-muted-foreground truncate w-full'>
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
          className='w-full justify-end text-center'
          onClick={() => column.toggleSorting(column.getIsSorted() === 'asc')}
        >
          {translation.discountPercentage}
          <ArrowUpDown className='ml-1 h-4 w-4' />
        </Button>
      ),
      cell: ({ row }) => (
        <span className='text-right'>{row.original.discountPercentage} %</span>
      ),
    },
    {
      id: 'price',
      header: ({ column }) => (
        <Button
          variant='ghost'
          className='w-full justify-end text-center'
          onClick={() => column.toggleSorting(column.getIsSorted() === 'asc')}
        >
          {translation.price}
          <ArrowUpDown className='ml-1 h-4 w-4' />
        </Button>
      ),
      accessorFn: (row) => row.price.initial,
      cell: ({ row }) => {
        const { initial, discounted } = row.original.price;

        return (
          <span className='text-center font-medium'>
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
          className='w-full justify-end text-right'
          onClick={() => column.toggleSorting(column.getIsSorted() === 'asc')}
        >
          {translation.quantity}
          <ArrowUpDown className='ml-1 h-4 w-4' />
        </Button>
      ),
      cell: ({ row }) => (
        <span className='text-right'>{row.getValue('quantity')}</span>
      ),
    },
  ];

  const actionsColumn: ColumnDef<T> = {
    header: translation.actions,
    enableHiding: false,
    cell: ({ row }) => {
      const [open, setOpen] = useState(false);
      const queryClient = useQueryClient();

      const handleDelete = async (id: string) => {
        onDelete(id);
        queryClient.invalidateQueries({
          queryKey: ['product', row.original.id],
        });
        setOpen(false);
      };

      const handleAddSuggestion = async () => {
        await httpClient.post('/products/graphics-cards/suggestions', {
          productId: row.original.id,
          suggestedProductSku: suggestionSku.current,
        });
        queryClient.invalidateQueries({
          queryKey: ['product', row.original.id],
        });
        setOpen(false);
      };

      const handleRemoveSuggestion = async () => {
        await httpClient.delete(
          `/products/graphics-cards/${row.original.id}/suggestions/${suggestionSku.current}`,
        );
        queryClient.invalidateQueries({
          queryKey: ['product', row.original.id],
        });
        setOpen(false);
      };

      return (
        <div className='flex items-center gap-3 justify-center'>
          {renderEditForm(row.original)}

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
                <DialogTitle>{translation.confirmDeletion}</DialogTitle>
                <DialogDescription>
                  {translation.areYouSureYouWantToDelete}{' '}
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
                  {translation.cancel}
                </Button>
                <Button
                  variant='destructive'
                  className='cursor-pointer bg-theme-crimson'
                  onClick={() => handleDelete(row.original.id)}
                >
                  {translation.delete}
                </Button>
              </DialogFooter>
            </DialogContent>
          </Dialog>

          <Dialog open={open} onOpenChange={setOpen}>
            <DialogTrigger asChild>
              <button
                className='h-4 w-4 p-0 hover:opacity-80 cursor-pointer'
                aria-label='Add suggestion'
              >
                <Plus className='h-4 w-4' />
              </button>
            </DialogTrigger>

            <DialogContent>
              <DialogHeader>
                <DialogTitle>Add a suggested product</DialogTitle>
                <DialogDescription>
                  Enter the SKU of the product you want to add
                </DialogDescription>
              </DialogHeader>

              <Input
                type='text'
                placeholder='ABCD1234'
                onChange={(e) => {
                  suggestionSku.current = e.target.value;
                }}
              />

              <DialogFooter className='flex justify-end gap-2'>
                <Button
                  className='cursor-pointer bg-theme-gunmetal text-white'
                  onClick={() => setOpen(false)}
                >
                  Cancel
                </Button>
                <Button
                  variant='destructive'
                  className='cursor-pointer bg-theme-crimson'
                  onClick={handleAddSuggestion}
                >
                  Add
                </Button>
              </DialogFooter>
            </DialogContent>
          </Dialog>

          <Dialog open={open} onOpenChange={setOpen}>
            <DialogTrigger asChild>
              <button
                className='h-4 w-4 p-0 hover:opacity-80 cursor-pointer'
                aria-label='Remove suggestion'
              >
                <Minus className='h-4 w-4' />
              </button>
            </DialogTrigger>

            <DialogContent>
              <DialogHeader>
                <DialogTitle>Remove a suggested product</DialogTitle>
                <DialogDescription>
                  Enter the SKU of the product you want to remove
                </DialogDescription>
              </DialogHeader>

              <Input
                type='text'
                placeholder='ABCD1234'
                onChange={(e) => {
                  suggestionSku.current = e.target.value;
                }}
              />

              <DialogFooter className='flex justify-end gap-2'>
                <Button
                  className='cursor-pointer bg-theme-gunmetal text-white'
                  onClick={() => setOpen(false)}
                >
                  Cancel
                </Button>
                <Button
                  variant='destructive'
                  className='cursor-pointer bg-theme-crimson'
                  onClick={handleRemoveSuggestion}
                >
                  Remove
                </Button>
              </DialogFooter>
            </DialogContent>
          </Dialog>
        </div>
      );
    },
  };

  return [...baseColumns, ...columns, actionsColumn] as ColumnDef<T>[];
}

type DatatableProps<T extends ProductLong> = PropsWithChildren & {
  data: T[];
  columns: ColumnDef<T>[];
  onDelete: (id: string) => void;
  renderEditForm: (product: T) => React.ReactNode;
};

export function DataTable<T extends ProductLong>({
  data,
  columns,
  onDelete,
  renderEditForm,
}: DatatableProps<T>) {
  const [sorting, setSorting] = useState<SortingState>([]);
  const [columnFilters, setColumnFilters] = useState<ColumnFiltersState>([]);
  const [columnVisibility, setColumnVisibility] = useState<VisibilityState>({});
  const [rowSelection, setRowSelection] = useState({});
  const suggestionSku = useRef<string>('');

  const {
    components: { dataTable },
  } = useTranslation();
  const sign = useCurrencyStore((state) => state.currency.sign);

  const table = useReactTable({
    data,
    columns: getColumns(
      columns,
      sign,
      onDelete,
      renderEditForm,
      dataTable,
      suggestionSku,
    ),
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
          placeholder={dataTable.searchBySku}
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
                {headerGroup.headers.map((header) => (
                  <TableHead
                    key={header.id}
                    className='bg-theme-gunmetal text-white align-middle'
                  >
                    {header.isPlaceholder
                      ? null
                      : flexRender(
                          header.column.columnDef.header,
                          header.getContext(),
                        )}
                  </TableHead>
                ))}
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
                  {row.getVisibleCells().map((cell) => {
                    return (
                      <TableCell
                        key={cell.id}
                        className={`border-r last:border-r-0 text-center`}
                      >
                        {flexRender(
                          cell.column.columnDef.cell,
                          cell.getContext(),
                        )}
                      </TableCell>
                    );
                  })}
                </TableRow>
              ))
            ) : (
              <TableRow>
                <TableCell
                  colSpan={columns.length}
                  className='h-24 text-center'
                >
                  {dataTable.noResults}
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
            className='cursor-pointer bg-theme-crimson text-white'
            onClick={() => table.previousPage()}
            disabled={!table.getCanPreviousPage()}
          >
            {dataTable.previous}
          </Button>
          <Button
            variant='outline'
            size='sm'
            className='cursor-pointer bg-theme-crimson text-white'
            onClick={() => table.nextPage()}
            disabled={!table.getCanNextPage()}
          >
            {dataTable.next}
          </Button>
        </div>
      </div>
    </div>
  );
}
