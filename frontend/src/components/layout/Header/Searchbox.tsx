import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { Search } from 'lucide-react';
import { Fragment, useState } from 'react';
import { useNavigate } from 'react-router';

export function Searchbox() {
  const [query, setQuery] = useState<string>('');
  const {
    components: { searchBox }
  } = useTranslation();
  const navigate = useNavigate();

  const handleSearch = () => {
    if (query !== '') {
      navigate(`/products/search?query=${query}`);
    }
  };

  return (
    <Fragment>
      <Input
        type='text'
        value={query}
        placeholder={searchBox.searchForProducts}
        onChange={(e) => setQuery(e.target.value)}
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
    </Fragment>
  );
}
