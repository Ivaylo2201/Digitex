import { Product } from '../../types/Product';
import { ProductCard } from './ProductCard';
import { useProducts } from '../../hooks/useProducts';

type ProductListProps = {
    category: string;
};

export const ProductsList = ({ category }: ProductListProps) => {
    const products: Product[] = useProducts(category);

    return (
        <main className='p-14 flex justify-center'>
            <div className='w-2/3 flex justify-center gap-8 flex-wrap'>
                {products.map((product, i) => {
                    return (
                        <ProductCard
                            key={i}
                            name={product.name}
                            image={product.image}
                            price={product.price}
                            pk={product.pk}
                            category={product.category}
                            base_price={product.base_price}
                            discount_percentage={product.discount_percentage}
                        />
                    );
                })}
            </div>
        </main>
    );
};
