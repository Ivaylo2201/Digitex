import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import { useTranslation } from '@/lib/stores/useTranslation';
import { Search } from 'lucide-react';
import React, { useState } from 'react';
import { useNavigate } from 'react-router';

export default function Searchbox() {
  const [search, setSearch] = useState<string>('');
  const translation = useTranslation();
  const navigate = useNavigate();

  const handleSearch = () => {
    if (search !== '') {
      navigate(`/products?search=${search}`);
    }
  };

  return (
    <React.Fragment>
      <Input
        type='text'
        placeholder={translation.keywords.productSearch}
        onChange={(e) => setSearch(e.target.value)}
        className='w-2/3 text-sm font-medium italic text-theme-gunmetal placeholder-theme-gunmetal! selection:bg-theme-crimson bg-theme-white ring-0 outline-none border-0 focus-visible:ring-0 data-[state=open]:ring-0 data-[state=open]:border-0'
      />
      <Button
        onClick={handleSearch}
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
