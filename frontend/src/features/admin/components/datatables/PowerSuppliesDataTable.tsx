import { DataTable } from './DataTable';
import { useProductDelete } from '../../hooks/useProductDelete';
import { useProducts } from '@/features/products/hooks/useProducts';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import type { ColumnDef } from '@tanstack/react-table';
import type { PowerSupply } from '@/features/products/models/PowerSupply';
import { PowerSupplyForm } from '../forms/PowerSupplyForm';

export function PowerSuppliesDataTable() {
  const { data } = useProducts<PowerSupply>('power-supplies', 1, 999);
  const { mutate: onDelete } = useProductDelete('power-supplies');
  const {
    components: { powerSuppliesDataTable },
  } = useTranslation();

  const columns: ColumnDef<PowerSupply>[] = [
    {
      id: 'wattage',
      header: powerSuppliesDataTable.wattage,
      cell: ({ row }) => {
        return <span>{row.original.wattage}</span>;
      },
    },
    {
      id: 'formFactor',
      header: powerSuppliesDataTable.formFactor,
      cell: ({ row }) => {
        return <span>{row.original.formFactor}</span>;
      },
    },
    {
      id: 'efficiencyPercentage',
      header: powerSuppliesDataTable.efficiencyPercentage,
      cell: ({ row }) => {
        return <span>{row.original.efficiencyPercentage}</span>;
      },
    },
    {
      id: 'modularity',
      header: powerSuppliesDataTable.modularity,
      cell: ({ row }) => {
        return <span>{row.original.modularity}</span>;
      },
    },
  ];

  return (
    <DataTable
      onDelete={onDelete}
      columns={columns}
      data={data?.items ?? ([] as any)}
      renderEditForm={(product) => <PowerSupplyForm product={product} />}
    />
  );
}
