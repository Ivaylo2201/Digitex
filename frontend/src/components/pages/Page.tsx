import Header from '../layout/Header/Header';

type PageProps = React.PropsWithChildren & { className?: string };

export default function Page({ children, className }: PageProps) {
  return (
    <div className='flex flex-col min-h-screen bg-theme-beige'>
      <Header />
      <main
        className={`flex justify-center items-center grow p-10 ${className}`}
      >
        {children}
      </main>
    </div>
  );
}
