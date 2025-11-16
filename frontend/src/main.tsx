import { createRoot } from 'react-dom/client';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import './index.css';
import Router from './Router';
import { Toaster } from 'sonner';

const queryClient = new QueryClient();

createRoot(document.getElementById('root')!).render(
  <QueryClientProvider client={queryClient}>
    <Router />
    <Toaster
      position='top-right'
      duration={1500}
      toastOptions={{
        style: {
          fontFamily: "'Montserrat', sans-serif"
        }
      }}
    />
  </QueryClientProvider>
);
