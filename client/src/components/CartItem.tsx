import CrossIcon from '../icons/CrossIcon';
import { CartItemProps } from '../types/CartItemProps';


export const CartItem = ({
    productName,
    productPrice,
    productImage,
    quantity
}: CartItemProps): JSX.Element => {
    return (
        <article className='relative w-72 flex gap-3 py-2 items-center font-Montserrat text-theme-darkblue'>
            <button className='w-5 h-5 ml-1 rounded-full flex justify-center items-center bg-theme-darkblue hover:bg-theme-blue text-xs text-theme-white font-Montserrat transition-colors duration-100'>
                <CrossIcon />
            </button>
            <div className='flex flex-grow gap-4'>
                <div className='w-16 flex items-center'>
                    <img
                        src={productImage}
                        alt=''
                    />
                </div>
                <div className='flex flex-col justify-center font-bold text-2xm'>
                    <p className='w-40 whitespace-nowrap overflow-hidden text-ellipsis'>
                        {productName}
                    </p>
                    <div className='flex gap-2'>
                        <span className='font-normal'>
                            {quantity}x
                        </span>
                        <p>${productPrice}</p>
                    </div>
                </div>
            </div>
        </article>
    );
};
