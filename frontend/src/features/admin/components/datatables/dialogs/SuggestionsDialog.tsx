import { Button } from '@/components/ui/button';
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from '@/components/ui/dialog';
import { Input } from '@/components/ui/input';
import { ScrollArea } from '@/components/ui/scroll-area';
import { useSuggested } from '@/features/admin/hooks/useSuggested';
import { useSuggestions } from '@/features/admin/hooks/useSuggestions';
import type { ProductShort } from '@/features/products/models/base/ProductShort';
import { useState } from 'react';
import { SuggestionCard } from '../../SuggestionCard';
import { SuggestedCard } from '../../SuggestedCard';
import { useTranslation } from '@/features/language/hooks/useTranslation';
import { PackageSearch } from 'lucide-react';

type SuggestionsDialogProps = {
  product: ProductShort;
  category?: string;
};

export function SuggestionsDialog({ product, category }: SuggestionsDialogProps) {
  const [open, setOpen] = useState(false);
  const [search, setSearch] = useState('');
  const {
    components: { suggestionsDialog },
  } = useTranslation();

  console.log(category)

  const { data: suggestions } = useSuggestions(product.id);
  const { data: suggested } = useSuggested(product.id);

  const filtered =
    suggestions?.filter((p) =>
      `${p.brandName} ${p.modelName}`
        .toLowerCase()
        .includes(search.toLowerCase()),
    ) ?? [];

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <Button variant='outline' size='sm' className='cursor-pointer'>
          <PackageSearch />
        </Button>
      </DialogTrigger>

      <DialogContent className='sm:max-w-4xl'>
        <DialogHeader>
          <DialogTitle>{suggestionsDialog.editingSuggestions}</DialogTitle>
          <DialogDescription>
            {suggestionsDialog.editingSuggestionsFor}{' '}
            <strong className='text-theme-gunmetal'>
              {product.brandName} {product.modelName}
            </strong>
          </DialogDescription>
        </DialogHeader>

        <div className='flex gap-6 w-full'>
          <div className='flex flex-col flex-1'>
            <ScrollArea className='h-[600px] w-full rounded-md'>
              <div className='p-4 space-y-3'>
                <h4 className='text-base font-semibold'>
                  {suggestionsDialog.productsForSuggestion}
                </h4>
                <Input
                  className='w-full mb-2'
                  placeholder={suggestionsDialog.searchProducts}
                  value={search}
                  onChange={(e) => setSearch(e.target.value)}
                />
                {filtered.map((suggestionProduct) => (
                  <SuggestionCard
                    key={suggestionProduct.id}
                    product={suggestionProduct}
                    baseProductId={product.id}
                    category={category}
                  />
                ))}
              </div>
            </ScrollArea>
          </div>

          <div className='flex-1'>
            <ScrollArea className='h-[600px] w-full rounded-md'>
              <div className='p-4 space-y-3'>
                <h4 className='text-base font-semibold'>
                  {suggestionsDialog.suggestedProducts}
                </h4>
                {suggested?.map((suggestedProduct) => (
                  <SuggestedCard
                    key={suggestedProduct.id}
                    product={suggestedProduct}
                    baseProductId={product.id}
                    category={category}
                  />
                ))}
              </div>
            </ScrollArea>
          </div>
        </div>
      </DialogContent>
    </Dialog>
  );
}
