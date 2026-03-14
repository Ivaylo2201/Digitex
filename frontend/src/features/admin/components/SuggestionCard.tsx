import { Button } from '@/components/ui/button';
import { Card, CardContent } from '@/components/ui/card';
import type { Suggestion } from '@/features/admin/types/Suggestion';
import { httpClient } from '@/lib/api/httpClient';
import { getStaticFile } from '@/lib/utils/getStaticFile';
import { useQueryClient } from '@tanstack/react-query';
import { Plus } from 'lucide-react';

export function SuggestionCard({
  product,
  baseProductId,
}: {
  product: Suggestion;
  baseProductId: string;
}) {
  const queryClient = useQueryClient();

  const handleAdd = async (product: Suggestion) => {
    await httpClient.post('/products/graphics-cards/suggestions', {
      productId: baseProductId,
      suggestionProductId: product.id,
    });

    queryClient.invalidateQueries({ queryKey: ['suggestions'] });
    queryClient.invalidateQueries({ queryKey: ['suggested'] });
  };

  return (
    <Card className='w-full hover:bg-muted/40 transition'>
      <CardContent className='flex items-center justify-between gap-4 py-2'>
        <div className='flex items-center gap-3'>
          <div className='h-14 w-14 shrink-0 overflow-hidden rounded-md border'>
            <img
              src={getStaticFile(product.imagePath)}
              alt={`${product.brandName} ${product.modelName}`}
              className='h-full w-full object-cover'
            />
          </div>

          <div className='flex flex-col leading-tight'>
            <span className='text-xs text-muted-foreground'>
              {product.brandName}
            </span>
            <span className='text-sm font-medium'>{product.modelName}</span>
          </div>
        </div>

        <Button
          className='shrink-0 cursor-pointer bg-theme-gunmetal hover:bg-theme-gunmetal/80'
          onClick={() => handleAdd(product)}
        >
          <Plus className='h-5 w-5 ' />
        </Button>
      </CardContent>
    </Card>
  );
}
