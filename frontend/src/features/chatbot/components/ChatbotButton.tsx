import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from '@/components/ui/popover';

import { BotMessageSquare } from 'lucide-react';
import { Chatbot } from './Chatbot';

export function ChatbotButton() {
  return (
    <Popover>
      <PopoverTrigger asChild>
        <button className='cursor-pointer fixed bottom-4 right-4 z-50 size-12 rounded-full bg-theme-crimson hover:bg-theme-lightcrimson transition-colors duration-200 flex items-center justify-center'>
          <BotMessageSquare size={22} className='text-white' />
        </button>
      </PopoverTrigger>

      <PopoverContent
        forceMount
        side='top'
        align='end'
        sideOffset={12}
        className='w-96 rounded-xl p-4 shadow-xl animate-in fade-in zoom-in-95 '
      >
        <Chatbot />
      </PopoverContent>
    </Popover>
  );
}
