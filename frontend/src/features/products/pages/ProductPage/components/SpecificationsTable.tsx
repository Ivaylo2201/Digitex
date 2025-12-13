import {
  Table,
  TableCaption,
  TableBody,
  TableRow,
  TableCell,
} from '@/components/ui/table';
import type { Specification } from '@/features/products/models/shared/Specification';
import { useTranslation } from '@/features/language/hooks/useTranslation';

type SpecificationsTableTableProps = { specifications: Specification[] };

export function SpecificationsTable({
  specifications,
}: SpecificationsTableTableProps) {
  const {
    components: { specificationsTable },
  } = useTranslation();

  return (
    <Table className='font-montserrat border border-gray-200'>
      <TableCaption>{specificationsTable.mainSpecifications}</TableCaption>
      <TableBody className='text-theme-gunmetal'>
        {specifications.map((specification, index) => (
          <TableRow
            className={`pointer-events-none ${
              index % 2 === 0 ? 'bg-gray-100' : ''
            }`}
            key={index}
          >
            <TableCell className='w-1/2'>
              {specification.specificationName}
            </TableCell>
            <TableCell className='w-1/2 font-medium'>
              {specification.value}
            </TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
}
