import type { GraphicsCard } from '@/features/products/models/GraphicsCard';
import type { ColumnDef } from 'node_modules/@tanstack/table-core/build/lib/types';
import { useProducts } from '@/features/products/hooks/useProducts';

import { useProductDelete } from '../../hooks/useProductDelete';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { DataTable } from './DataTable';
import { GraphicsCardForm } from '../forms/GraphicsCardsForm';

export function GraphicsCardsDataTable() {
  const { data } = useProducts<GraphicsCard>('graphics-cards', 1, 999);
  const { mutate: onDelete } = useProductDelete('graphics-cards');
  const {
    components: { graphicsCardsDataTable },
  } = useTranslation();

  const columns: ColumnDef<GraphicsCard>[] = [
    {
      id: 'memory',
      header: graphicsCardsDataTable.memory,
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
      header: graphicsCardsDataTable.clock,
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
      header: graphicsCardsDataTable.busWidth,
      cell: ({ row }) => row.original.busWidth,
    },
    {
      accessorKey: 'cudaCores',
      header: graphicsCardsDataTable.cudaCores,
      cell: ({ row }) => row.original.cudaCores,
    },
    {
      accessorKey: 'directXSupport',
      header: graphicsCardsDataTable.directXSupport,
      cell: ({ row }) => row.original.directXSupport,
    },
    {
      accessorKey: 'tdp',
      header: graphicsCardsDataTable.tdp,
      cell: ({ row }) => row.original.tdp,
    },
  ];

  return (
    <DataTable
      onDelete={(id) => onDelete(id)}
      columns={columns}
      data={data?.items ?? ([] as any)}
      renderEditForm={(product) => <GraphicsCardForm product={product} />}
    />
  );
}
