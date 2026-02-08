import { useProducts } from '@/features/products/hooks/useProducts';
import type { Monitor } from '@/features/products/models/Monitor';
import { useProductDelete } from '../../hooks/useProductDelete';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import type { ColumnDef } from 'node_modules/@tanstack/table-core/build/lib/types';
import { DataTable } from './DataTable';
import { MonitorForm } from '../forms/MonitorForm';

export function MonitorsDataTable() {
  const { data } = useProducts<Monitor>('monitors', 1, 999);
  const { mutate: onDelete } = useProductDelete('monitors');
  const {
    components: { monitorsDataTable },
    units,
  } = useTranslation();

  const columns: ColumnDef<Monitor>[] = [
    {
      id: 'displayDiagonal',
      header: monitorsDataTable.displayDiagonal,
      cell: ({ row }) => <span>{row.original.displayDiagonal}"</span>,
    },
    {
      id: 'refreshRate',
      header: monitorsDataTable.refreshRate,
      cell: ({ row }) => (
        <span>
          {row.original.refreshRate} {units.hertz}
        </span>
      ),
    },
    {
      id: 'latency',
      header: monitorsDataTable.latency,
      cell: ({ row }) => (
        <span>
          {row.original.latency} {units.milliseconds}
        </span>
      ),
    },
    {
      id: 'matrix',
      header: monitorsDataTable.matrix,
      cell: ({ row }) => <span>{row.original.matrix}</span>,
    },
    {
      id: 'resolution',
      header: monitorsDataTable.resolution,
      cell: ({ row }) => {
        const r = row.original.resolution;
        return (
          <span>
            {r.width} x {r.height} {r.type}
          </span>
        );
      },
    },
    {
      id: 'pixelSize',
      header: monitorsDataTable.pixelSize,
      cell: ({ row }) => (
        <span>
          {row.original.pixelSize} {units.millimeters}
        </span>
      ),
    },
    {
      id: 'brightness',
      header: monitorsDataTable.brightness,
      cell: ({ row }) => (
        <span>
          {row.original.brightness} {units.nits}
        </span>
      ),
    },
    {
      id: 'colorSpectre',
      header: monitorsDataTable.colorSpectre,
      cell: ({ row }) => <span>{row.original.colorSpectre}%</span>,
    },
  ];

  return (
    <DataTable
      onDelete={onDelete}
      columns={columns}
      data={data?.items ?? ([] as any)}
      renderEditForm={(product) => <MonitorForm product={product} />}
    />
  );
}
