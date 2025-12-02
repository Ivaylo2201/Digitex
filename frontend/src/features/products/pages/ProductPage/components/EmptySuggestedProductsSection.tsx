import {
  Empty,
  EmptyHeader,
  EmptyMedia,
  EmptyTitle,
  EmptyDescription,
} from '@/components/ui/empty';

import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { MonitorX } from 'lucide-react';

export function EmptySuggestedProductsSection() {
  const {
    components: { emptySuggestedProductsSection },
  } = useTranslation();

  return (
    <Empty>
      <EmptyHeader>
        <EmptyMedia variant='icon'>
          <MonitorX />
        </EmptyMedia>
        <EmptyTitle>
          {emptySuggestedProductsSection.noSuggestedProductsAvailable}
        </EmptyTitle>
        <EmptyDescription>
          <p>{emptySuggestedProductsSection.thisProductHasNoSuggestionsYet}</p>
        </EmptyDescription>
      </EmptyHeader>
    </Empty>
  );
}
