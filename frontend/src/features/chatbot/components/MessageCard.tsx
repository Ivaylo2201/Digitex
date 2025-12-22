import { Ellipsis } from 'lucide-react';
import type { Message } from '../types/Message';
import { Avatar } from './Avatar';

type MessageCardProps = {
  sender: Omit<Message['sender'], 'system'>;
  content: string;
  isLoading: boolean;
};

export function MessageCard({ sender, content, isLoading }: MessageCardProps) {
  const isUser = sender === 'user';

  return (
    <li
      className={`flex items-center gap-3 font-montserrat ${
        isUser ? 'flex-row-reverse' : 'flex-row'
      }`}
    >
      <Avatar sender={sender} />

      <p className='max-w-xs bg-gray-200 p-3 rounded-xl wrap-break-word text-sm'>
        {isLoading ? <Ellipsis size={14} /> : content}
      </p>
    </li>
  );
}
