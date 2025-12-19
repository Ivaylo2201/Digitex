import { ScrollArea } from '@radix-ui/react-scroll-area';
import { EmptyMessagesSection } from './EmptyMessagesSection';
import { MessageCard } from './MessageCard';
import type { Message } from '../types/Message';

type MessagesListProps = { messages: Message[] };

export function MessagesList({ messages }: MessagesListProps) {
  return (
    <ScrollArea className='h-96 rounded-md'>
      {messages.length === 1 ? (
        <EmptyMessagesSection />
      ) : (
        <div className='flex flex-col gap-3 pr-4 pl-2'>
          {messages
            .filter((message) => message.sender !== 'system')
            .map((message, i) => (
              <MessageCard
                key={i}
                {...message}
                isLoading={message.isLoading ?? false}
              />
            ))}
        </div>
      )}
    </ScrollArea>
  );
}
