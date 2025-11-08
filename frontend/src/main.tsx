import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import './index.css';
import { BrowserRouter, Routes, Route } from 'react-router';
import Page from './components/pages/Page';

const queryClient = new QueryClient();

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<Page></Page>} />
          <Route path='/products/:category' element={<Page></Page>} />
        </Routes>
      </BrowserRouter>
    </QueryClientProvider>
  </StrictMode>
);
