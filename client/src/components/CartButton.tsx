import CartIcon from '../icons/CartIcon';
import { CartWindow } from './CartWindow';
import { useCart } from './CartContextProvider';

export const CartButton = (): JSX.Element => {
    const { cartData, isCartOpen, setIsCartOpen } = useCart();

    return (
        <div className='relative inline-flex flex-col justify-center items-center'>
            <button
                onClick={() => setIsCartOpen(!isCartOpen)}
                className='relative flex flex-col justify-center items-center cursor-pointer'
            >
                {cartData.cartitems_count > 0 && (
                    <span className='w-5 h-5 flex justify-center items-center absolute -top-2 -right-1 rounded-full bg-theme-lightcrimson text-xs text-theme-white font-Montserrat '>
                        {cartData.cartitems_count}
                    </span>
                )}
                <CartIcon />
                <span className='text-theme-white text-xm font-Montserrat'>
                    Your cart
                </span>
            </button>
            {isCartOpen && <CartWindow />}
        </div>
    );
};
