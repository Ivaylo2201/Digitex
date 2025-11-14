import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue
} from '@/components/ui/select';

import { useLanguage } from '@/lib/i18n/hooks/useLanguage';

export default function LanguageSelect() {
  const { language, languages, changeLanguage } = useLanguage();

  return (
    <Select value={language} onValueChange={changeLanguage}>
      <SelectTrigger className='w-23 font-montserrat text-xs shadow-none ring-0 outline-none border-0 focus-visible:ring-0 data-[state=open]:ring-0 data-[state=open]:border-0 cursor-pointer'>
        <SelectValue>
          <LanguageOption code={language} />
        </SelectValue>
      </SelectTrigger>
      <SelectContent>
        {languages.map((language, idx) => (
          <SelectItem className='cursor-pointer' key={idx} value={language}>
            <LanguageOption code={language} />
          </SelectItem>
        ))}
      </SelectContent>
    </Select>
  );
}

function LanguageOption({ code }: { code: string }) {
  return (
    <div className='flex items-center gap-2 font-montserrat text-xs'>
      <img
        src={new URL(`/src/assets/flags/${code}.png`, import.meta.url).href}
        alt={`${code}-flag`}
        className='size-4.5 rounded-full object-cover'
      />
      <span>{code.toUpperCase()}</span>
    </div>
  );
}
