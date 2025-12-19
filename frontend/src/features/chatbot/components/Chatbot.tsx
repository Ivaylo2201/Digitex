import { useRef, useState } from 'react';
import type { Message } from '../types/Message';
import { useChatbot } from '../hooks/useChatbot';
import { toast } from 'sonner';
import { Input } from '@/components/ui/input';

export function Chatbot() {
  const [prompt, setPrompt] = useState('');
  const [messages, setMessages] = useState<Message[]>([]);
  const initialContextMessageSent = useRef(false);
  const { promptChatbot } = useChatbot();

  const onMessageSend = async () => {
    if (!prompt.trim()) {
      toast.error('Please enter a message.');
      return;
    }

    if (!initialContextMessageSent.current) {
      addMessage({
        sender: 'system',
        content: import.meta.env.VITE_CHATBOT_CONTEXT,
      });
      initialContextMessageSent.current = true;
    }

    const userMessage: Message = { sender: 'user', content: prompt };

    addMessage(userMessage);
    addMessage({ sender: 'chatbot', content: 'Thinking...', isLoading: true });

    console.log([userMessage, ...messages]);

    const res = await promptChatbot([userMessage, ...messages]);
    //markMessageAsLoaded(res);
    setPrompt('');
  };

  const addMessage = (chatMessage: Message) =>
    setMessages((messages) => [...messages, chatMessage]);

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
    <div>
      <div className='min-h-[200px] max-w-[500px] border border-gray-300 p-2'>
        {messages
          .filter((chatMessage) => chatMessage.sender !== 'system')
          .map((chatMessage, i) => (
            <div
              key={i}
              className={
                chatMessage.sender === 'user' ? 'text-right' : 'text-left'
              }
            >
              <strong>{chatMessage.sender}:</strong> {chatMessage.content}
            </div>
          ))}
      </div>

      <Input
        onChange={(e) => setPrompt(e.target.value)}
        value={prompt}
        type='text'
        placeholder='Type your message...'
      />
      <button onClick={onMessageSend}>Send</button>
    </div>
  );
}
