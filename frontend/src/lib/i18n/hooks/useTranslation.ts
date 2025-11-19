import type { Language } from '../models/Language';
import type { Translation } from '../models/Translation';
import { useLanguage } from './useLanguage';
import { translation } from '../models/Translation';
import bgTranslation from '../languages/bg.json';
import deTranslatation from '../languages/de.json';

const translations: Record<Language, Translation> = {
  en: translation,
  de: deTranslatation as Translation,
  bg: bgTranslation as Translation,
};

export function useTranslation(): Translation {
  const { language } = useLanguage();
  return translations[language];
}
