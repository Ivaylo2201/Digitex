import { create } from 'zustand';
import type { Language } from '../models/Language';

type LanguageStore = {
  language: Language;
  languages: Language[];
  changeLanguage: (language: Language) => void;
};

export const useLanguage = create<LanguageStore>((set) => {
  const envLanguages = import.meta.env.VITE_APP_LANGUAGES as string;
  const languages = envLanguages.split(',') as Language[];

  return {
    language: languages[0],
    languages,
    changeLanguage: (language) => set(() => ({ language })),
  };
});
