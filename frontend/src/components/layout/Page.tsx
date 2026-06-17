import { Navbar } from '@/components/layout/Navbar/Navbar';
import { Header } from './Header/Header';
import { Footer } from './Footer/Footer';
import { ChatbotButton } from '@/features/chatbot/components/ChatbotButton';

type PageProps = React.PropsWithChildren & {
  className?: string;
  /**
   * Full-bleed layout: drops the centered, padded content well so a page can
   * render edge-to-edge sections (e.g. the home page hero). Defaults to false.
   */
  bleed?: boolean;
};

export function Page({ children, className = '', bleed = false }: PageProps) {
  return (
    <div className='flex flex-col min-h-screen bg-theme-beige font-montserrat'>
      <Header />
      <Navbar />
      <main
        className={
          bleed
            ? `flex flex-col grow ${className}`
            : `flex justify-center items-center grow px-10 py-16 ${className}`
        }
      >
        {children}
      </main>
      <ChatbotButton />
      <Footer />
    </div>
  );
}
