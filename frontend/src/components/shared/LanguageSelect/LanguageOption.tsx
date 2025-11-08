type LanguageOptionProps = {
  code: string;
};

export default function LanguageOption({ code }: LanguageOptionProps) {
  return (
    <div className='w-14 flex items-center gap-2 font-montserrat text-xs'>
      <img
        src={new URL(`/src/assets/flags/${code}.png`, import.meta.url).href}
        alt={`${code}-flag`}
        className='size-4.5 rounded-full object-cover'
      />
      <span>{code.toUpperCase()}</span>
    </div>
  );
}
