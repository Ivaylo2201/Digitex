import { useEffect, useState } from 'react';
import axios, { AxiosResponse } from 'axios';
import { Product } from '../../types/Product';
import { ProductCard } from './ProductCard';


export const ProductsList: React.FC<{ category: string }> = ({ category }) => {
    const [products, setProducts] = useState<Product[]>([]);

    useEffect(() => {
        fetchProducts();
    }, [category]);

    const fetchProducts = async () => {
        const url: string = `http://localhost:8000/api/products/${category}/`;

        try {
            const response: AxiosResponse<Product[]> = await axios.get(url);
            setProducts(response.data);
        } catch (error) {
            console.error(error);
        }
    };

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
