import {
  Breadcrumb,
  BreadcrumbItem,
  BreadcrumbList,
  BreadcrumbPage,
  BreadcrumbSeparator
} from '@/components/ui/breadcrumb';

import { useTranslation } from '@/features/language/hooks/useTranslation';
import { capitalize } from '@/lib/utils/capitalize';
import { Link } from 'react-router';

type ProductPageBreadcrumb = {
  category: string;
  displayName: string;
};

export function ProductPageBreadcrumb({
  category,
  displayName
}: ProductPageBreadcrumb) {
  const {
    components: { productPageBreadcrumb },
    routeNames
  } = useTranslation();

  return (
    <Breadcrumb>
      <BreadcrumbList>
        <BreadcrumbItem>
          <Link className='text-md' to='/'>
            {productPageBreadcrumb.home}
          </Link>
        </BreadcrumbItem>
        <BreadcrumbSeparator />
        <BreadcrumbItem>
          <Link className='text-md' to={`/products/categories/${category}`}>
            {capitalize((routeNames as Record<string, string>)[category])}
          </Link>
        </BreadcrumbItem>
        <BreadcrumbSeparator />
        <BreadcrumbItem>
          <BreadcrumbPage>
            <p className='text-md'>{displayName}</p>
          </BreadcrumbPage>
        </BreadcrumbItem>
      </BreadcrumbList>
    </Breadcrumb>
  );
}
