import { useState } from 'react';
import type { Message } from '../types/Message';
import { useChatbot } from '../hooks/useChatbot';
import { Input } from '@/components/ui/input';
import { Send } from 'lucide-react';
import { Button } from '@/components/ui/button';
import { MessagesList } from './MessagesList';
import { useTranslation } from '@/features/language/hooks/useTranslation';

export function Chatbot() {
  const [prompt, setPrompt] = useState('');
  const [messages, setMessages] = useState<Message[]>([
    { sender: 'system', content: import.meta.env.VITE_CHATBOT_CONTEXT },
  ]);
  const { promptChatbot } = useChatbot();
  const {
    components: { chatbot },
  } = useTranslation();

  const handleMessageSend = async () => {
    const message: Message = { sender: 'user', content: prompt };
    setPrompt('');

    setMessages((messages) => [
      ...messages,
      message,
      { sender: 'chatbot', content: '', isLoading: true },
    ]);

    const res = await promptChatbot([message, ...messages]);
    markMessageAsLoaded(res.response);
  };

  const markMessageAsLoaded = (content: string) => {
    setMessages((messages) => {
      const updated = [...messages];
      updated[updated.length - 1] = {
        sender: 'chatbot',
        content,
      };
      return updated;
    });
  };

  return (
    <div className='flex flex-col gap-4 font-montserrat'>
      <MessagesList messages={messages} />

      <div className='flex gap-2 items-center'>
        <Input
          onChange={(e) => setPrompt(e.target.value)}
          value={prompt}
          type='text'
          placeholder={chatbot.typeYourMessage}
          className='flex-1 h-10 text-sm font-medium italic text-theme-gunmetal placeholder-theme-gunmetal! selection:bg-theme-crimson bg-theme-white ring-0 outline-none focus-visible:ring-0 data-[state=open]:ring-0'
        />
        <Button
          disabled={
            messages[messages.length - 1]?.isLoading || prompt.trim() === ''
          }
          onClick={handleMessageSend}
          className='w-10 h-10 rounded-full bg-theme-crimson hover:bg-theme-lightcrimson flex items-center justify-center transition-colors duration-200'
        >
          <Send size={18} className='text-white' />
        </Button>
      </div>
    </div>
  );
}
