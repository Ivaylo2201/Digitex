import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue
} from '@/components/ui/select';
import { useState } from 'react';
import Language from './Language';

const languages = ['en', 'bg', 'de'];

export default function LanguageSelect() {
  const [selectedLanguage, setSelectedLanguage] = useState<string>(languages[0]);

  const handleLanguageChange = (language: string) => {
    setSelectedLanguage(language);
  };

  return (
    <Select value={selectedLanguage} onValueChange={handleLanguageChange}>
      <SelectTrigger className='w-23 font-montserrat text-xs shadow-none ring-0 outline-none border-0 focus-visible:ring-0 data-[state=open]:ring-0 data-[state=open]:border-0 cursor-pointer'>
        <SelectValue>
          <Language code={selectedLanguage} />
        </SelectValue>
      </SelectTrigger>
      <SelectContent>
        {languages.map((language) => (
          <SelectItem className='cursor-pointer' key={language} value={language}>
            <Language code={language} />
          </SelectItem>
        ))}
      </SelectContent>
    </Select>
  );
}
