import { useTranslation } from '@/features/language/hooks/useTranslation';

export function Footer() {
  const {
    components: { footer },
  } = useTranslation();

  return (
    <footer className='border-t-4 border-theme-crimson'>
      <div className='flex justify-center items-center gap-5 bg-theme-eerie-black text-white py-5'>
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
