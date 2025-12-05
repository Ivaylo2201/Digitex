type LanguageOptionProps = { code: string };

export function LanguageOption({ code }: LanguageOptionProps) {
  const flagSrc = new URL(`/src/assets/flags/${code}.png`, import.meta.url).href;

  return (
    <div className='flex items-center gap-2 font-montserrat text-xs'>
      <img
        src={flagSrc}
        alt={`${code}-flag`}
        className='size-4.5 rounded-full object-cover'
      />
      <span>{code.toUpperCase()}</span>
    </div>
  );
}
