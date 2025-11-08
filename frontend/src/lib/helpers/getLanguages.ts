export default function getLanguages() {
  try {
    return (import.meta.env.VITE_APP_LANGUAGES as string).split(',')
  } catch (ex) {
    console.error("Failed to configure languages for application. Add 'VITE_APP_LANGUAGES' to .env")
    return [];
  }
}