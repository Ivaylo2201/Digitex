import CartIcon from '../../icons/CartIcon';
import { useCart } from '../context/CartContextProvider';
import { useLogger } from '../context/LogContextProvider';
import { CartItemsCounter } from './CartItemsCounter';
import { CartWindow } from './CartWindow';
import { useNavigate } from 'react-router-dom';

export const CartButton: React.FC = () => {
    const { cartData, isCartOpen, setIsCartOpen } = useCart();
    const { isLoggedIn } = useLogger();
    const navigate = useNavigate();

    const dispatch = (): void => {
        if (isLoggedIn) {
            setIsCartOpen(!isCartOpen);
        } else {
            navigate('accounts/signin/');
        }
    };

    return (
        <div className='relative inline-flex flex-col justify-center items-center'>
            <button
                onClick={dispatch}
                className='relative flex flex-col justify-center items-center cursor-pointer'
            >
                {isLoggedIn && (
                    <CartItemsCounter count={cartData.cartitems_count} />
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
