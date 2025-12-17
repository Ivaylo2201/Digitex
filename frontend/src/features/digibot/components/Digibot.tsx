import { useRef, useState } from 'react';
import type { ChatMessage } from '../types/ChatMessage';
import { toast } from 'sonner';
import { Input } from '@/components/ui/input';
import { useOpenAi } from '../hooks/useOpenAi';

// TODO: Finish using ScrollArea

// in env
// `You are a helpful chatbot assistant for the online ecommerce store Digitex. The user is about to ask you a question soon, so be ready to answer them shortly and cleanly please match their language - the website supports english bulgarian and german`;

export function Digibot() {
  const [prompt, setPrompt] = useState('');
  const [chatMessages, setChatMessages] = useState<ChatMessage[]>([]);
  const initialContextMessageSent = useRef(false);
  const { callOpenAi } = useOpenAi();

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

    const userMessage: ChatMessage = { sender: 'user', content: prompt };

    addMessage(userMessage);
    addMessage({ sender: 'chatbot', content: 'Thinking...', isLoading: true });

    const res = await callOpenAi([userMessage, ...chatMessages]);
    markMessageAsLoaded(res.choices[0].message.content);
    setPrompt('');
  };

  const addMessage = (chatMessage: ChatMessage) =>
    setChatMessages((chatMessages) => [...chatMessages, chatMessage]);

  const markMessageAsLoaded = (content: string) => {
    setChatMessages((chatMessages) => {
      const updated = [...chatMessages];
      updated[updated.length - 1] = {
        sender: 'chatbot',
        content,
        isLoading: false,
      };
      return updated;
    });
  };

  return (
    <div>
      <div className='min-h-[200px] max-w-[500px] border border-gray-300 p-2'>
        {chatMessages
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
