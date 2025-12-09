import type { BaseFilters } from '../../types/BaseFilters';
import { RangeSlider } from '../RangeSlider';
import { Button } from '@/components/ui/button';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { CheckboxList } from '../CheckboxList';

type FilterFormProps = React.PropsWithChildren<{ filters: BaseFilters }>;

export function FilterForm({ filters, children }: FilterFormProps) {
  const {
    components: { filterForm },
  } = useTranslation();

  return (
    <form className='w-[250px] flex flex-col gap-6'>
      <CheckboxList title={'Brands'} data={filters.brands} />
      <RangeSlider title={filterForm.price} />
      {children}
      <Button
        type='submit'
        className='w-full bg-theme-crimson hover:bg-theme-lightcrimson cursor-pointer duration-200 transition-colors'
      >
        {filterForm.apply}
      </Button>
    </form>
  );
}
