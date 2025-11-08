import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import './index.css';
import Header from './components/layout/Header';
import { BrowserRouter, Routes, Route } from 'react-router';

const queryClient = new QueryClient();

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<Header />} />
        </Routes>
      </BrowserRouter>
      {/* <ToastContainer
          autoClose={500}
          pauseOnHover={false}
          toastStyle={{
            fontFamily: 'Rubik, sans-serif',
            backgroundColor: 'var(--color-theme-beige)'
          }}
          closeButton={false}
        /> */}
    </QueryClientProvider>
  </StrictMode>
);
