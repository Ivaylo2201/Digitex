import { useProducts } from '@/features/products/hooks/useProducts';
import { useProductDelete } from '../../hooks/useProductDelete';
import type { ColumnDef } from 'node_modules/@tanstack/table-core/build/lib/types';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { DataTable } from './DataTable';
import type { Processor } from '@/features/products/models/Processor';
import { ProcessorForm } from '../forms/ProcessorForm';

export function ProcessorsDataTable() {
  const { data } = useProducts<Processor>('processors', 1, 999);
  const { mutate: onDelete } = useProductDelete('processors');
  const {
    components: { processorsDataTable },
  } = useTranslation();

  const columns: ColumnDef<Processor>[] = [
    {
      id: 'cores',
      header: processorsDataTable.cores,
      cell: ({ row }) => {
        return <span>{row.original.cores}</span>;
      },
    },
    {
      id: 'threads',
      header: processorsDataTable.threads,
      cell: ({ row }) => {
        return <span>{row.original.threads}</span>;
      },
    },
    {
      id: 'clock',
      header: processorsDataTable.clockSpeed,
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
      id: 'socket',
      header: processorsDataTable.socket,
      cell: ({ row }) => {
        return <span>{row.original.socket}</span>;
      },
    },
    {
      id: 'tdp',
      header: processorsDataTable.tdp,
      cell: ({ row }) => {
        return <span>{row.original.tdp}</span>;
      },
    },
  ];

  return (
    <DataTable
      onDelete={onDelete}
      columns={columns}
      data={data?.items ?? ([] as any)}
      renderEditForm={(product) => <ProcessorForm product={product} />}
    />
  );
}
