import type { GraphicsCard } from '@/features/products/models/GraphicsCard';
import type { ColumnDef } from 'node_modules/@tanstack/table-core/build/lib/types';
import { useProducts } from '@/features/products/hooks/useProducts';
import { DataTable } from './Datatable';

export function GraphicsCardsDatatable() {
  const { data } = useProducts('graphics-cards', 1, 999);
  const columns: ColumnDef<GraphicsCard>[] = [
    {
      id: 'memory',
      header: 'Memory',
      cell: ({ row }) => {
        const { capacityInGb, type, frequency } = row.original.memory;
        return (
          <span>
            {capacityInGb} GB {type}, {frequency}
          </span>
        );
      },
    },
    {
      id: 'clock',
      header: 'Clock',
      cell: ({ row }) => {
        const { base, boost } = row.original.clockSpeed;
        return (
          <span>
            {boost.toFixed(2)} / {base.toFixed(2)} GHz
          </span>
        );
      },
    },
    {
      accessorKey: 'busWidth',
      header: 'Bus Width',
      cell: ({ row }) => row.original.busWidth,
    },
    {
      accessorKey: 'cudaCores',
      header: 'CUDA Cores',
      cell: ({ row }) => row.original.cudaCores,
    },
    {
      accessorKey: 'directXSupport',
      header: 'DirectX',
      cell: ({ row }) => row.original.directXSupport,
    },
    {
      accessorKey: 'tdp',
      header: 'TDP (W)',
      cell: ({ row }) => row.original.tdp,
    },
  ];

  return (
    <DataTable
      onDelete={() => {}}
      columns={columns as any}
      data={data?.items ?? ([] as any)}
    />
  );
}
