import { create } from 'zustand'
import type { Language } from '../types/language';

type LanguageStore = {
  language: Language,
  languages: Language[]
  changeLanguage: (language: Language) => void;
}

export const useLanguage = create<LanguageStore>((set) => {
  const languages = (import.meta.env.VITE_APP_LANGUAGES as string).split(',') as Language[];

  return ({
    language: languages[0],
    languages,
    changeLanguage: (language) => set(() => ({ language }))
  })
});