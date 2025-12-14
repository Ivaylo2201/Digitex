import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';

import { useLanguage } from '@/features/language/hooks/useLanguage';
import { LanguageOption } from './LanguageOption';

export function LanguageSelect() {
  const { language, languages, changeLanguage } = useLanguage();

  return (
    <Select
      value={language.languageIsoCode}
      onValueChange={(languageIsoCode) => changeLanguage({ languageIsoCode })}
    >
      <SelectTrigger className='w-23 font-montserrat text-xs shadow-none ring-0 outline-none border-0 focus-visible:ring-0 data-[state=open]:ring-0 data-[state=open]:border-0 cursor-pointer'>
        <SelectValue>
          <LanguageOption code={language.languageIsoCode} />
        </SelectValue>
      </SelectTrigger>
      <SelectContent>
        {languages.map((language, index) => (
          <SelectItem
            className='cursor-pointer'
            key={index}
            value={language.languageIsoCode}
          >
            <LanguageOption code={language.languageIsoCode} />
          </SelectItem>
        ))}
      </SelectContent>
    </Select>
  );
}
