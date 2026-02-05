import type { GraphicsCard } from '@/features/products/models/GraphicsCard';
import type { ColumnDef } from 'node_modules/@tanstack/table-core/build/lib/types';
import { useProducts } from '@/features/products/hooks/useProducts';
import { GraphicsCardForm } from './GraphicsCardsForm';
import { DataTable } from './DataTable';
import { useProductDelete } from '../hooks/useProductDelete';
import { useTranslation } from '@/features/language/hooks/useTranslation';

export function GraphicsCardsDatatable() {
  const { data } = useProducts<GraphicsCard>('graphics-cards', 1, 999);
  const { mutate: onDelete } = useProductDelete('graphics-cards');
  const {
    components: { graphicsCardDatatable },
  } = useTranslation();

  const columns: ColumnDef<GraphicsCard>[] = [
    {
      id: 'memory',
      header: graphicsCardDatatable.memory,
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
      header: graphicsCardDatatable.clock,
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
      header: graphicsCardDatatable.busWidth,
      cell: ({ row }) => row.original.busWidth,
    },
    {
      accessorKey: 'cudaCores',
      header: graphicsCardDatatable.cudaCores,
      cell: ({ row }) => row.original.cudaCores,
    },
    {
      accessorKey: 'directXSupport',
      header: graphicsCardDatatable.directXSupport,
      cell: ({ row }) => row.original.directXSupport,
    },
    {
      accessorKey: 'tdp',
      header: graphicsCardDatatable.tdp,
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
