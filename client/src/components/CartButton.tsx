import { useState } from 'react';
import CartIcon from '../icons/CartIcon';
import { CartWindow } from './CartWindow';

export const CartButton = (): JSX.Element => {
    //TODO: Make a hook and replace stuff here
    const [isCartOpen, setIsCartOpen] = useState<boolean>(false);

    const toggle = (): void => setIsCartOpen(!isCartOpen);

    return (
        <div className='relative inline-flex flex-col justify-center items-center'>
            <button
                onClick={toggle}
                className='relative flex flex-col justify-center items-center cursor-pointer'
            >
                <span className='w-5 h-5 flex justify-center items-center absolute -top-1 -right-1 rounded-full bg-theme-lightcrimson text-xs text-theme-white font-Montserrat '>
                    4
                </span>
                <CartIcon />
                <span className='text-theme-white text-xm font-Montserrat'>
                    Your cart
                </span>
            </button>
            {isCartOpen && <CartWindow />}
        </div>
    );
}
