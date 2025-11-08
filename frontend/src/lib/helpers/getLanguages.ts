import type { Language } from '../types/language';

export default function getLanguages() {
  try {
    const languages = (import.meta.env.VITE_APP_LANGUAGES as string).split(',');
    return languages as Language[];
  } catch (ex) {
    console.error(
      "Failed to configure languages for application. Add 'VITE_APP_LANGUAGES' to .env"
    );
    return [];
  }
}
