import {
  TableHeader,
  TableRow,
  TableHead,
  TableBody,
  TableCell,
  Table
} from '@/components/ui/table';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import type { Processor } from '@/features/products/models/Processor';

type ProcessorCompareTableProps = { products: ProductLong[] };

export default function ProcessorCompareTable({
  products
}: ProcessorCompareTableProps) {
  return (
    <Table>
      <TableHeader>
        <TableRow>
          <TableHead>Cores</TableHead>
          <TableHead>Threads</TableHead>
          <TableHead>Clock</TableHead>
          <TableHead>Socket</TableHead>
          <TableHead>TDP</TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        {products.map((product) => {
          const processor = product as Processor;

          return (
            <TableRow key={processor.id}>
              <TableCell>{processor.cores}</TableCell>
              <TableCell>{processor.threads}</TableCell>
              <TableCell>{`${processor.clockSpeed.base} / ${processor.clockSpeed.boost} GHz`}</TableCell>
              <TableCell>{processor.socket}</TableCell>
              <TableCell>{processor.tdp} W</TableCell>
            </TableRow>
          );
        })}
      </TableBody>
    </Table>
  );
}
