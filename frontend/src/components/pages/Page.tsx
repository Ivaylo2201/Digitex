import Header from '@/components/layout/Header/Header';
import Navbar from '@/components/layout/Navbar/Navbar';

type PageProps = React.PropsWithChildren & { className?: string };

export default function Page({ children, className }: PageProps) {
  return (
    <div className='flex flex-col min-h-screen bg-theme-beige font-montserrat'>
      <Header />
      <Navbar />
      <main
        className={`flex justify-center items-center grow p-10 ${className}`}
      >
        {children}
      </main>
    </div>
  );
}
