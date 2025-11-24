import { Spinner } from '@/components/ui/spinner';
import type { Translation } from '@/lib/i18n/models/Translation';

type LoaderProps = { translation: Translation };

export function Loader({ translation }: LoaderProps) {
  return (
    <div className='flex justify-center items-center gap-2'>
      <Spinner className='size-8 text-theme-crimson' />
      <span className='font-medium text-theme-gunmetal'>
        {translation.keywords.loading}...
      </span>
    </div>
  );
}
