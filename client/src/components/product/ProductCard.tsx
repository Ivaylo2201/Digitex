import { useState } from 'react';
import { DiscountLabel } from './DiscountLabel';
import { QuantityButton } from './QuantityButton';
import { useCart } from '../context/CartContextProvider';
import { Product } from '../../types/Product';
import { MinusIcon } from '../../icons/MinusIcon';
import { PlusIcon } from '../../icons/PlusIcon';

export const ProductCard: React.FC<Product> = ({
    pk,
    name,
    category,
    base_price,
    price,
    discount_percentage,
    image
}) => {
    const { addToCart } = useCart();
    const [quantity, setQuantity] = useState<number>(1);

    const incrementQuantity = (): void =>
        setQuantity((q) => (q < 25 ? q + 1 : q));
    const decrementQuantity = (): void =>
        setQuantity((q) => (q > 1 ? q - 1 : q));

    return (
        <article className='bg-theme-white relative inline-flex flex-col gap-6 items-center px-5 py-8 font-Montserrat border-2 rounded-lg border-theme-gray transition-colors duration-150 hover:border-theme-crimson'>
            {discount_percentage > 0 && (
                <DiscountLabel amount={discount_percentage} />
            )}
            <img src={image} className='w-56 h-40 object-contain' />
            <div className='text-center'>
                <span className='text-theme-darkgray text-2xm'>{category}</span>
                <p className='font-bold'>{name}</p>
                <div className='flex gap-2 justify-center items-center'>
                    <span className='font-bold text-xl text-theme-crimson'>
                        {`$${price}`}
                    </span>
                    {discount_percentage > 0 && (
                        <span className='line-through text-theme-darkgray'>
                            {`$${base_price}`}
                        </span>
                    )}
                </div>
            </div>
            <div className='flex gap-5 items-center'>
                <div className='w-24 h-8 flex justify-center'>
                    <QuantityButton
                        callback={decrementQuantity}
                        Icon={MinusIcon}
                    />
                    <div className='w-8 h-full flex justify-center items-center'>
                        {quantity}
                    </div>
                    <QuantityButton
                        callback={incrementQuantity}
                        Icon={PlusIcon}
                    />
                </div>
                <button
                    onClick={() => addToCart(pk, quantity)}
                    className='uppercase bg-theme-crimson hover:bg-theme-lightcrimson px-8 py-2 rounded-full text-theme-white transition-colors duration-200'
                >
                    Buy
                </button>
            </div>
        </article>
    );
};
