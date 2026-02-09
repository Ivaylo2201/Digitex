import { DataTable } from './DataTable';
import { useProductDelete } from '../../hooks/useProductDelete';
import { useProducts } from '@/features/products/hooks/useProducts';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import type { ColumnDef } from '@tanstack/react-table';
import type { Ssd } from '@/features/products/models/Ssd';
import { SsdForm } from '../forms/SsdForm';

export function SsdsDataTable() {
  const { data } = useProducts<Ssd>('ssds', 1, 999);
  const { mutate: onDelete } = useProductDelete('ssds');
  const {
    components: { ssdsDataTable },
  } = useTranslation();

  const columns: ColumnDef<Ssd>[] = [
    {
      id: 'capacityInGb',
      header: ssdsDataTable.capacityInGb,
      cell: ({ row }) => <span>{row.original.capacityInGb}</span>,
    },
    {
      id: 'operationSpeed.read',
      header: ssdsDataTable.operationSpeed.read,
      cell: ({ row }) => {
        return <span>{row.original.operationSpeed.read}</span>;
      },
    },
    {
      id: 'operationSpeed.write',
      header: ssdsDataTable.operationSpeed.write,
      cell: ({ row }) => {
        return <span>{row.original.operationSpeed.write}</span>;
      },
    },
    {
      id: 'storageInterface',
      header: ssdsDataTable.storageInterface,
      cell: ({ row }) => <span>{row.original.storageInterface}</span>,
    },
  ];

  return (
    <DataTable
      onDelete={onDelete}
      columns={columns}
      data={data?.items ?? ([] as any)}
      renderEditForm={(product) => <SsdForm product={product} />}
    />
  );
}
