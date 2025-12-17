import axios from 'axios';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { toast } from 'sonner';
import type { ChatMessage } from '../types/ChatMessage';

type Completion = {
  message: {
    role: 'assistant';
    content: string;
  };
};

type OpenAiResponse = {
  choices: Completion[];
};

export function useOpenAi() {
  const { hooks } = useTranslation();

  const callOpenAi = async (messages: ChatMessage[]) => {
    console.log('calling')

    try {
      const res = await axios.post<OpenAiResponse>(
        'https://api.openai.com/v1/chat/completions',
        {
          model: 'gpt-4.1-mini',
          messages,
        },
        {
          headers: {
            Authorization: `Bearer ${import.meta.env.VITE_OPENAI_API_KEY}`,
          },
        }
      );

      return res.data;
    } catch {
      toast.error(hooks.generic.somethingWentWrong);

      const response = {
        choices: [
          {
            message: {
              role: 'assistant',
              content: hooks.generic.somethingWentWrong,
            },
          },
        ],
      };

      return response as OpenAiResponse;
    }
  };

  return { callOpenAi };
}
