import { Spinner } from '@/components/ui/spinner';
import { useTranslation } from '@/features/language/hooks/useTranslation';

export function Loader() {
  const {
    components: { loader }
  } = useTranslation();

  return (
    <div className='flex justify-center items-center gap-2'>
      <Spinner className='size-8 text-theme-crimson' />
      <span className='font-medium text-theme-gunmetal'>
        {loader.loading}...
      </span>
    </div>
  );
}
