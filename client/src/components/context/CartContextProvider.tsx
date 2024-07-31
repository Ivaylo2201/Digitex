import axios, { AxiosResponse } from 'axios';
import { createContext, useContext, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { CartItem } from '../../types/CartItem';
import getAuthHeaders from '../../utils/getAuthHeaders';

type Cart = {
    subtotal: number;
    cartitems: CartItem[];
    cartitems_count: number;
};

interface CartContextType {
    cartData: Cart;
    isCartOpen: boolean;
    setIsCartOpen: React.Dispatch<React.SetStateAction<boolean>>;
    addToCart: (pk: number, quantity: number) => void;
    removeFromCart: (pk: number) => void;
    placeOrder: () => void;
    fetchCartData: () => void;
}

type ProviderProps = {
    children: React.ReactNode;
};

const CartContext = createContext<CartContextType | null>(null);

export const useCart = (): CartContextType => {
    const context = useContext(CartContext);
    if (!context) {
        throw new Error();
    }
    return context;
};

export const CartProvider: React.FC<ProviderProps> = ({ children }) => {
    const [cartData, setCartData] = useState<Cart>({
        subtotal: 0,
        cartitems: [],
        cartitems_count: 0
    });
    const [isCartOpen, setIsCartOpen] = useState<boolean>(false);
    const navigate = useNavigate();

    useEffect(() => {
        if (isCartOpen) {
            fetchCartData();
        }
    }, [isCartOpen]);

    const fetchCartData = async (): Promise<void> => {
        const url: string = 'http://localhost:8000/api/cart/';

        try {
            const response: AxiosResponse<Cart> = await axios.get(
                url,
                getAuthHeaders()
            );
            setCartData(response.data);
        } catch (error) {
            console.error(error);
        }
    };

    const addToCart = async (
        product: number,
        quantity: number
    ): Promise<void> => {
        const url: string = 'http://localhost:8000/api/cart/add/';

        const body = {
            product: product,
            quantity: quantity
        };

        try {
            await axios.post(url, body, getAuthHeaders());
            fetchCartData();
        } catch (error) {
            if (axios.isAxiosError(error) && error.response?.status === 401) {
                navigate('/accounts/signin');
            } else {
                console.error(error);
            }
        }
    };

    const removeFromCart = async (pk: number): Promise<void> => {
        const url: string = `http://localhost:8000/api/cart/remove/${pk}/`;

        try {
            await axios.delete(url, getAuthHeaders());
            fetchCartData();
        } catch (error) {
            console.error(error);
        }
    };

    const placeOrder = async (): Promise<void> => {
        const url: string = 'http://localhost:8000/api/order/place/';

        try {
            await axios.post(url, {}, getAuthHeaders());
            fetchCartData();
        } catch (error) {
            console.error(error);
        }
    };

    const contextValue: CartContextType = {
        cartData,
        isCartOpen,
        setIsCartOpen,
        addToCart,
        removeFromCart,
        placeOrder,
        fetchCartData
    };

    return (
        <CartContext.Provider value={contextValue}>
            {children}
        </CartContext.Provider>
    );
};