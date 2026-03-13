import {
  Empty,
  EmptyDescription,
  EmptyHeader,
  EmptyMedia,
  EmptyTitle
} from '@/components/ui/empty';
import { X } from 'lucide-react';

export function EmptyProducts() {
  return (
    <Empty>
      <EmptyHeader>
        <EmptyMedia variant='icon'>
          <X />
        </EmptyMedia>
        <EmptyTitle>No products found.</EmptyTitle>
        <EmptyDescription>
          <p>No products match you desired criteria</p>
          <p className='flex justify-center items-center gap-1.5'>
            Adjust the criteria or try again later
          </p>
        </EmptyDescription>
      </EmptyHeader>
    </Empty>
  );
}
