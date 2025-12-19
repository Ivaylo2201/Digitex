import { httpClient } from '@/lib/api/httpClient';
import type { Message } from '../types/Message';

export function useChatbot() {
  const promptChatbot = async (messages: Message[]) => {
    try {
      const { data } = await httpClient.post<{ response: string }>('/chatbot', {
        messages,
      });
      return data;
    } catch {
      return { response: 'Something went wrong.' };
    }
  };

  return { promptChatbot };
}
