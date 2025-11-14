import {
  Breadcrumb,
  BreadcrumbItem,
  BreadcrumbList,
  BreadcrumbPage,
  BreadcrumbSeparator
} from '@/components/ui/breadcrumb';
import { capitalize } from '@/lib/utils/capitalize';
import { Link } from 'react-router';

type ProductPageBreadcrumb = {
  category: string;
  displayName: string;
};

export default function ProductPageBreadcrumb({
  category,
  displayName
}: ProductPageBreadcrumb) {
  return (
    <Breadcrumb>
      <BreadcrumbList>
        <BreadcrumbItem>
          <Link to='/'>Home</Link>
        </BreadcrumbItem>
        <BreadcrumbSeparator />
        <BreadcrumbItem>
          <Link to={`/products/categories/${category}`}>
            {capitalize(category)}
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
