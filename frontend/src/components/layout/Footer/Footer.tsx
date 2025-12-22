import { useTranslation } from '@/features/language/hooks/useTranslation';

export function Footer() {
  const {
    components: { footer },
  } = useTranslation();

  const mapSrc = `https://www.google.com/maps?q=${
    import.meta.env.VITE_MERCHANT_ADDRESS
  }&output=embed`;

  return (
    <footer className='border-t-4 border-theme-crimson'>
      <div className='flex justify-center items-center gap-5 bg-theme-eerie-black text-white py-8'>
        <iframe
          src={mapSrc}
          className='w-[400px] h-[200px] border-0'
          allowFullScreen
          loading='lazy'
        />
      </div>
      <div className='flex justify-center items-center gap-5 bg-theme-gunmetal text-white py-3'>
        <span>© {new Date().getFullYear()}</span>
        <span className='uppercase font-bold text-3xl text-theme-white'>
          digite
          <span className='text-theme-crimson'>x</span>
        </span>
        <span>{footer.allRightsReserved}</span>
      </div>
    </footer>
  );
}
