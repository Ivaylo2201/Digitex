import { BotMessageSquare, User } from 'lucide-react';
import { Fragment } from 'react';
import type { Message } from '../types/Message';

type AvatarProps = { sender: Omit<Message['sender'], 'system'> };

export function Avatar({ sender }: AvatarProps) {
  return (
    <div className='relative w-9 h-9 shrink-0 rounded-full bg-theme-gunmetal flex items-center justify-center text-white'>
      {sender === 'chatbot' ? (
        <Fragment>
          <BotMessageSquare size={19} />
          <span className='absolute bottom-0 right-0 w-2.5 h-2.5 rounded-full bg-green-400 border border-theme-gunmetal' />
        </Fragment>
      ) : (
        <User size={19} />
      )}
    </div>
  );
}
