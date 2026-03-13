import {
  Empty,
  EmptyDescription,
  EmptyHeader,
  EmptyMedia,
  EmptyTitle
} from '@/components/ui/empty';
import { X } from 'lucide-react';

export function EmptyFavorites() {
  return (
    <Empty>
      <EmptyHeader>
        <EmptyMedia variant='icon'>
          <X />
        </EmptyMedia>
        <EmptyTitle>You have no favorited products.</EmptyTitle>
        <EmptyDescription>
          <p>You have not saved any products as favorites</p>
          <p className='flex justify-center items-center gap-1.5'>
            Get started by clicking the heart button on an item
          </p>
        </EmptyDescription>
      </EmptyHeader>
    </Empty>
  );
}
