import type { Translation } from '../types/translation';
import { useLanguage } from './useLanguage';
import enJson from '@/lib/i18n/en.json';
import deJson from '@/lib/i18n/de.json';
import bgJson from '@/lib/i18n/bg.json';
import type { Language } from '../types/language';

const translations: Record<Language, Translation> = {
  en: enJson as Translation,
  de: deJson as Translation,
  bg: bgJson as Translation
};

export function useTranslation(): Translation {
  const { language } = useLanguage();
  return translations[language];
}
