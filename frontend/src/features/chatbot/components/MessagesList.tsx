import { MessageCard } from './MessageCard';
import type { Message } from '../types/Message';
import { ScrollArea } from '@/components/ui/scroll-area';
import { EmptyMessagesSection } from './EmptyMessagesSection';

type MessagesListProps = { messages: Message[] };

export function MessagesList({ messages }: MessagesListProps) {
  if (messages.length === 1) {
    return (
      <div className='h-96'>
        <EmptyMessagesSection />
      </div>
    );
  }

  return (
    <ScrollArea className='h-96'>
      <ul className='p-2 flex flex-col gap-3'>
        {messages
          .filter((m) => m.sender !== 'system')
          .map((m, i) => (
            <MessageCard key={i} {...m} isLoading={!!m.isLoading} />
          ))}
      </ul>
    </ScrollArea>
  );
}
