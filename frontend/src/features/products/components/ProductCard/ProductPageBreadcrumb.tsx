import {
  Breadcrumb,
  BreadcrumbItem,
  BreadcrumbList,
  BreadcrumbPage,
  BreadcrumbSeparator,
} from '@/components/ui/breadcrumb';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';
import { capitalize } from '@/lib/utils/capitalize';
import { Link } from 'react-router';

type ProductPageBreadcrumb = {
  category: string;
  displayName: string;
};

export function ProductPageBreadcrumb({
  category,
  displayName,
}: ProductPageBreadcrumb) {
  const translation = useTranslation();

  return (
    <Breadcrumb>
      <BreadcrumbList>
        <BreadcrumbItem>
          <Link to='/'>{translation.routing.home}</Link>
        </BreadcrumbItem>
        <BreadcrumbSeparator />
        <BreadcrumbItem>
          <Link to={`/products/categories/${category}`}>
            {capitalize(
              (translation.routing as Record<string, string>)[category]
            )}
          </Link>
        </BreadcrumbItem>
        <BreadcrumbSeparator />
        <BreadcrumbItem>
          <BreadcrumbPage>{displayName}</BreadcrumbPage>
        </BreadcrumbItem>
      </BreadcrumbList>
    </Breadcrumb>
  );
}
