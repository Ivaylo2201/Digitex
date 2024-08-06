import { useEffect, useState } from 'react';
import { Product } from '../types/Product';
import axios, { AxiosResponse } from 'axios';

export const useProducts = (category: string): Product[] => {
    const [products, setProducts] = useState<Product[]>([]);

    useEffect(() => {
        const fetchProducts = async () => {
            const url: string = `http://localhost:8000/api/products/${category}/`;

            try {
                const response: AxiosResponse<Product[]> = await axios.get(url);
                setProducts(response.data);
            } catch (error) {
                console.error(error);
            }
        };

        fetchProducts();
    }, [category]);

    return products;
};
