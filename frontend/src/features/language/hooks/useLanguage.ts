import { create } from 'zustand';
import type { Language } from '../models/Language';

type LanguageStore = {
  language: Language;
  languages: Language[];
  changeLanguage: (language: Language) => void;
};

export const useLanguage = create<LanguageStore>((set) => {
  const languages: Language[] = [
    { languageIsoCode: 'EN' },
    { languageIsoCode: 'BG' },
    { languageIsoCode: 'DE' },
  ];

  return {
    language: languages[0],
    languages,
    changeLanguage: (language) => set(() => ({ language })),
  };
});
