import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import { useTranslation } from '@/lib/stores/useTranslation';
import { Search } from 'lucide-react';
import React from 'react';

export default function Searchbox() {
  const translation = useTranslation();

  return (
    <React.Fragment>
      <Input
        type='email'
        placeholder={translation.productSearch}
        className='w-2/3 text-sm font-semibold placeholder-theme-eerie-black! selection:bg-theme-crimson bg-theme-white text-theme-eerie-black ring-0 outline-none border-0 focus-visible:ring-0 data-[state=open]:ring-0 data-[state=open]:border-0'
      />
      <Button
        variant='outline'
        size='icon'
        aria-label='Submit'
        className='cursor-pointer bg-theme-eerie-black hover:bg-theme-eerie-black text-xs text-theme-white hover:text-theme-white ring-0 outline-none border-0 focus-visible:ring-0 data-[state=open]:ring-0 data-[state=open]:border-0'
      >
        <Search />
      </Button>
    </React.Fragment>
  );
}
