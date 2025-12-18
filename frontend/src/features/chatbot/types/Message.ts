export type Message = {
  sender: 'user' | 'chatbot' | 'system';
  content: string;
  isLoading?: boolean;
};
