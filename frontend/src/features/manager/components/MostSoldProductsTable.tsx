import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableFooter,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table';

type Product = {
  sku: string;
  brandName: string;
  modelName: string;
  price: {
    initial: number;
    discounted: number;
  };
  unitsSold: number;
  quantity: number;
  rating: number;
};

const products: Product[] = [
  {
    sku: 'SKU-001',
    brandName: 'Apple',
    modelName: 'iPhone 15',
    price: { initial: 999, discounted: 899 },
    unitsSold: 1200,
    quantity: 50,
    rating: 4.8,
  },
  {
    sku: 'SKU-002',
    brandName: 'Samsung',
    modelName: 'Galaxy S23',
    price: { initial: 899, discounted: 799 },
    unitsSold: 950,
    quantity: 40,
    rating: 4.6,
  },
  {
    sku: 'SKU-003',
    brandName: 'Sony',
    modelName: 'WH-1000XM5',
    price: { initial: 399, discounted: 349 },
    unitsSold: 700,
    quantity: 30,
    rating: 4.7,
  },
  {
    sku: 'SKU-004',
    brandName: 'Dell',
    modelName: 'XPS 13',
    price: { initial: 1299, discounted: 1199 },
    unitsSold: 500,
    quantity: 20,
    rating: 4.5,
  },
  {
    sku: 'SKU-005',
    brandName: 'Nike',
    modelName: 'Air Max 270',
    price: { initial: 150, discounted: 120 },
    unitsSold: 2000,
    quantity: 100,
    rating: 4.4,
  },
];

export function MostSoldProductsTable() {
  const totalRevenue = products.reduce(
    (sum, p) => sum + p.price.discounted * p.quantity,
    0,
  );

  return (
    <Table>
      <TableCaption>Most sold products</TableCaption>

      <TableHeader>
        <TableRow>
          <TableHead className='w-[100px]'>SKU</TableHead>
          <TableHead>Brand</TableHead>
          <TableHead>Model</TableHead>
          <TableHead className='text-right'>Price</TableHead>
          <TableHead className='text-right'>Units Sold</TableHead>
          <TableHead className='text-right'>Quantity</TableHead>
          <TableHead className='text-right'>Rating</TableHead>
        </TableRow>
      </TableHeader>

      <TableBody>
        {products.map((product) => (
          <TableRow key={product.sku}>
            <TableCell className='font-medium'>{product.sku}</TableCell>
            <TableCell>{product.brandName}</TableCell>
            <TableCell>{product.modelName}</TableCell>
            <TableCell className='text-right'>
              ${product.price.discounted.toFixed(2)}
            </TableCell>
            <TableCell className='text-right'>{product.unitsSold}</TableCell>
            <TableCell className='text-right'>{product.quantity}</TableCell>
            <TableCell className='text-right'>{product.rating}</TableCell>
          </TableRow>
        ))}
      </TableBody>

      <TableFooter>
        <TableRow>
          <TableCell colSpan={6}>Total Revenue</TableCell>
          <TableCell className='text-right'>
            ${totalRevenue.toFixed(2)}
          </TableCell>
        </TableRow>
      </TableFooter>
    </Table>
  );
}
