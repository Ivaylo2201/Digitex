import { translation, type Translation } from '../models/Translation';
import { useLanguage } from './useLanguage';
import bgTranslation from '@/lib/i18n/resources/bg.json';
import deTranslation from '@/lib/i18n/resources/de.json';

const translations: Record<string, Translation> = {
  en: translation,
  de: deTranslation as Translation,
  bg: bgTranslation as Translation,
};

export function useTranslation(): Translation {
  const { language } = useLanguage();
  return translations[language.languageIsoCode.toLowerCase()];
}
