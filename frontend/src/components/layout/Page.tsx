import { Navbar } from '@/components/layout/Navbar/Navbar';
import { Header } from './Header/Header';
import { Footer } from './Footer/Footer';
import { ChatbotButton } from '@/features/chatbot/components/ChatbotButton';

type PageProps = React.PropsWithChildren & { className?: string };

export function Page({ children, className = '' }: PageProps) {
  return (
    <div className='flex flex-col min-h-screen bg-theme-beige font-montserrat'>
      <Header />
      <Navbar />
      <main
        className={`flex justify-center items-center grow px-10 py-16 ${className}`}
      >
        {children}
      </main>
      <ChatbotButton />
      <Footer />
    </div>
  );
}
