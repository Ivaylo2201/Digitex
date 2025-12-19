import {
  Empty,
  EmptyHeader,
  EmptyMedia,
  EmptyTitle,
  EmptyDescription,
} from '@/components/ui/empty';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { BotMessageSquare } from 'lucide-react';

export function EmptyMessagesSection() {
  const {
    components: { emptyMessagesSection },
  } = useTranslation();

  return (
    <Empty>
      <EmptyHeader>
        <EmptyMedia variant='icon' className='bg-theme-gunmetal'>
          <BotMessageSquare className='text-white' />
        </EmptyMedia>
        <EmptyTitle>
          {emptyMessagesSection.hiThereImYourDigitexAssistant}
        </EmptyTitle>
        <EmptyDescription>
          <p className='flex justify-center items-center gap-1.5'>
            {emptyMessagesSection.imHereToHelpAskMeAnything}
          </p>
        </EmptyDescription>
      </EmptyHeader>
    </Empty>
  );
}
