export function getStaticFile(imagePath: string) {
  return `${import.meta.env.VITE_STATIC_FILES_URL}/${imagePath}`;
}
