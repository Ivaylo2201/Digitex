import {
  Table,
  TableCaption,
  TableBody,
  TableRow,
  TableCell
} from '@/components/ui/table';
import type { Spec } from '@/features/products/models/shared/Spec';
import type { Translation } from '@/lib/i18n/models/Translation';

type SpecsTableProps = { specs: Spec[]; translation: Translation };

export function SpecsTable({ specs, translation }: SpecsTableProps) {
  return (
    <Table className='font-montserrat border border-gray-200'>
      <TableCaption>{translation.keywords.mainSpecifications}</TableCaption>
      <TableBody className='text-theme-gunmetal'>
        {specs.map((item, index) => (
          <TableRow
            className={`pointer-events-none ${
              index % 2 === 0 ? 'bg-gray-100' : ''
            }`}
            key={index}
          >
            <TableCell className='w-1/2'>{item.spec}</TableCell>
            <TableCell className='w-1/2 font-medium'>{item.value}</TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
}
