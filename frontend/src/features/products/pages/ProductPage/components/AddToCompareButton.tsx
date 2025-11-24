import { Button } from '@/components/ui/button';
import { useCompare } from '@/features/compare/stores/useCompare';
import type { ProductLong } from '@/features/products/models/base/ProductLong';
import type { Translation } from '@/lib/i18n/models/Translation';
import { ArrowLeftRight } from 'lucide-react';
import { toast } from 'sonner';

type AddToCompareButtonProps = {
  product: ProductLong;
  category: string;
  translation: Translation;
};

export function AddToCompareButton({
  product,
  category,
  translation
}: AddToCompareButtonProps) {
  const { addToCompare } = useCompare();

  const handleAddToCompare = () => {
    const addToCompareResult = addToCompare(
      { ...product, category },
      translation
    );

    if (addToCompareResult.isSuccess) {
      toast.success(addToCompareResult.message);
    } else {
      toast.error(addToCompareResult.message);
    }
  };

  return (
    <Button
      onClick={handleAddToCompare}
      className='bg-theme-gunmetal hover:bg-theme-crimson transition-colors duration-300 cursor-pointer'
    >
      <ArrowLeftRight />
    </Button>
  );
}
