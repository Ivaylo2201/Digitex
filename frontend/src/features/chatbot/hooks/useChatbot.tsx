import { httpClient } from '@/lib/api/httpClient';
import type { Message } from '../types/Message';

export function useChatbot() {
  const promptChatbot = async (messages: Message[]) => {
    const res = await httpClient.post<{ response: string }>('/chatbot', {
      messages,
    });
    return res.data;
  };

  return { promptChatbot };
}
