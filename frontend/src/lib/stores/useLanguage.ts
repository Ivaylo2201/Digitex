import { create } from 'zustand'
import getLanguages from '../helpers/getLanguages';
import type { Language } from '../types/language';

type LanguageStore = {
  language: Language,
  languages: Language[]
  changeLanguage: (language: Language) => void;
}

export const useLanguage = create<LanguageStore>((set) => {
  const languages = getLanguages();

  return ({
    language: languages[0],
    languages,
    changeLanguage: (language) => set(() => ({ language }))
  })
});