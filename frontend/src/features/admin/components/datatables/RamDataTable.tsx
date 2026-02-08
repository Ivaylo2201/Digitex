import type { Ram } from '@/features/products/models/Ram';
import { DataTable } from './DataTable';
import { useProductDelete } from '../../hooks/useProductDelete';
import { useProducts } from '@/features/products/hooks/useProducts';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import type { ColumnDef } from '@tanstack/react-table';
import { RamForm } from '../forms/RamForm';

export function RamDataTable() {
  const { data } = useProducts<Ram>('rams', 1, 999);
  const { mutate: onDelete } = useProductDelete('rams');
  const {
    components: { ramsDataTable },
  } = useTranslation();

  const columns: ColumnDef<Ram>[] = [
    {
      id: 'memory',
      header: ramsDataTable.memory,
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
      id: 'timing',
      header: ramsDataTable.timing,
      cell: ({ row }) => <span>{row.original.timing}</span>,
    },
  ];

  return (
    <DataTable
      onDelete={onDelete}
      columns={columns}
      data={data?.items ?? ([] as any)}
      renderEditForm={(product) => <RamForm product={product} />}
    />
  );
}
