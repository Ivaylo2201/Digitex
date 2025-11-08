import { useEffect, useState } from 'react';
import type { Translation } from '@/lib/types/translation';
import { useLanguage } from '@/lib/stores/useLanguage';

export default function useTranslation() {
  const { language } = useLanguage();
  const [translation, setTranslation] = useState<Translation | null>(null);

  useEffect(() => {
    import(`@/lib/i18n/${language}.json`).then((translation) =>
      setTranslation(translation as Translation)
    );
  }, [language]);

  return translation;
}
