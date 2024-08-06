import CrossIcon from "../../icons/CrossIcon";
import { CartItem } from "../../types/CartItem";
import { useCart } from "../context/CartContextProvider";
import { CartItemImage } from "./CartItemImage";


export const CartItemCard = ({ pk, product, quantity }: CartItem) => {
    const { removeFromCart } = useCart();

    return (
        <article className='relative w-72 flex gap-4 py-2 items-center font-Montserrat text-theme-darkblue'>
            <button
                onClick={() => removeFromCart(pk)}
                className='w-5 h-5 ml-1 rounded-full flex justify-center items-center bg-theme-darkblue hover:bg-theme-blue text-xs text-theme-white font-Montserrat transition-colors duration-100'
            >
                <CrossIcon />
            </button>
            <div className='flex flex-grow gap-4'>
                <CartItemImage image={product.image} />
                <div className='flex flex-col justify-center font-bold text-2xm'>
                    <p className='w-40 whitespace-nowrap overflow-hidden text-ellipsis'>
                        {product.name}
                    </p>
                    <div className='flex gap-2'>
                        <span className='font-normal'>{quantity}x</span>
                        <p>${product.price}</p>
                    </div>
                </div>
            </div>
        </article>
    );
};
