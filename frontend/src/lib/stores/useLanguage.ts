import { create } from 'zustand'
import getLanguages from '../helpers/getLanguages';

type LanguageStore = {
  language: string,
  languages: string[]
  changeLanguage: (language: string) => void;
}

export const useLanguage = create<LanguageStore>((set) => {
  const languages = getLanguages();

  return ({
    language: languages[0],
    languages,
    changeLanguage: (language) => set(() => ({ language }))
  })
});