export type ChatMessage = {
  sender: 'user' | 'chatbot' | 'system';
  content: string;
  isLoading?: boolean
};
