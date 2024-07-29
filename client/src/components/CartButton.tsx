import CartIcon from '../icons/CartIcon';
import { CartWindow } from './CartWindow';
import { useCart } from './CartContextProvider';
import { useLogger } from './LogContextProvider';
import { NavigateFunction, useNavigate } from 'react-router-dom';

export const CartButton: React.FC = () => {
    const { cartData, isCartOpen, setIsCartOpen } = useCart();
    const { isLoggedIn } = useLogger()
    const navigate: NavigateFunction = useNavigate()

    const dispatch = (): void => {
        if (isLoggedIn) {
            setIsCartOpen(!isCartOpen)
        } else {
            navigate('accounts/signin/');
        }
    }

    return (
        <div className='relative inline-flex flex-col justify-center items-center'>
            <button
                onClick={dispatch}
                className='relative flex flex-col justify-center items-center cursor-pointer'
            >
                {cartData.cartitems_count > 0 && (
                    <span className='w-5 h-5 flex justify-center items-center absolute -top-2 -right-1 rounded-full bg-theme-crimson text-xs text-theme-white font-Montserrat '>
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
