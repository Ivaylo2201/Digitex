import { useProducts } from '@/features/products/hooks/useProducts';
import type { Motherboard } from '@/features/products/models/Motherboard';
import { useProductDelete } from '../../hooks/useProductDelete';
import type { ColumnDef } from 'node_modules/@tanstack/table-core/build/lib/types';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { DataTable } from './DataTable';
import { MotherboardForm } from '../forms/MotherboardForm';

export function MotherboardsDataTable() {
  const { data } = useProducts<Motherboard>('motherboards', 1, 999);
  const { mutate: onDelete } = useProductDelete('motherboards');
  const {
    components: { motherboardsDataTable },
  } = useTranslation();

  const columns: ColumnDef<Motherboard>[] = [
    {
      id: 'socket',
      header: motherboardsDataTable.socket,
      cell: ({ row }) => {
        return <span>{row.original.socket}</span>;
      },
    },
    {
      id: 'formFactor',
      header: motherboardsDataTable.formFactor,
      cell: ({ row }) => {
        return <span>{row.original.formFactor}</span>;
      },
    },
    {
      id: 'chipset',
      header: motherboardsDataTable.chipset,
      cell: ({ row }) => {
        return <span>{row.original.chipset}</span>;
      },
    },
    {
      id: 'ramSlots',
      header: motherboardsDataTable.ramSlots,
      cell: ({ row }) => {
        return <span>{row.original.ramSlots}</span>;
      },
    },
    {
      id: 'pcieSlots',
      header: motherboardsDataTable.pcieSlots,
      cell: ({ row }) => {
        return <span>{row.original.pcieSlots}</span>;
      },
    },
  ];

  return (
    <DataTable
      onDelete={onDelete}
      columns={columns}
      data={data?.items ?? ([] as any)}
      renderEditForm={(product) => <MotherboardForm product={product} />}
    />
  );
}
