import type { ProductLong } from '@/lib/models/products/ProductLong';
import {
  Breadcrumb,
  BreadcrumbItem,
  BreadcrumbList,
  BreadcrumbPage,
  BreadcrumbSeparator
} from '../ui/breadcrumb';
import { Link } from 'react-router';
import { capitalize } from '@/lib/helpers';

type ProductPageBreadcrumb = {
  category: string;
  product: ProductLong;
};

export default function ProductPageBreadcrumb({
  category,
  product
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
          <BreadcrumbPage>{`${product.brandName} ${product.modelName}`}</BreadcrumbPage>
        </BreadcrumbItem>
      </BreadcrumbList>
    </Breadcrumb>
  );
}
