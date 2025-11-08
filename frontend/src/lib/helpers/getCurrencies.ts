export default function getCurrencies() {
  try {
    return (import.meta.env.VITE_APP_CURRENCIES as string).split(',')
  } catch (ex) {
    console.error("Failed to configure currencies for application. Add 'VITE_APP_CURRENCIES' to .env")
    return [];
  }
}