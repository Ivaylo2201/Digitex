import { useState } from 'react';
import { Product } from '../types/Product';
import { useCart } from './CartContextProvider';
import { DiscountLabel } from './DiscountLabel';
import { PlusIcon } from '../icons/PlusIcon';
import { MinusIcon } from '../icons/MinusIcon';
import { QuantityButton } from './QuantityButton';

export const ProductCard = ({
    pk,
    name,
    category,
    base_price,
    price,
    discount_percentage,
    image
}: Product): JSX.Element => {
    const { addToCart } = useCart();
    const [quantity, setQuantity] = useState<number>(1);

    const incrementQuantity = (): void =>
        setQuantity((q) => (q < 25 ? q + 1 : q));
    const decrementQuantity = (): void =>
        setQuantity((q) => (q > 1 ? q - 1 : q));

    return (
        <article className='bg-theme-white relative inline-flex flex-col gap-4 items-center px-5 py-8 font-Montserrat border-2 rounded-lg border-theme-gray transition-colors duration-150 hover:border-theme-lightcrimson '>
            {discount_percentage > 0 && (
                <DiscountLabel amount={discount_percentage} />
            )}
            <img src={image} className='w-56 h-40 object-contain' />
            <div className='text-center'>
                <span className='text-theme-darkgray text-2xm'>
                    {category}
                </span>
                <p className='font-bold'>{name}</p>
                <div className='flex gap-2 justify-center items-center'>
                    <span className='font-bold text-xl text-theme-lightcrimson'>
                        {`$${price}`}
                    </span>
                    {discount_percentage > 0 && (
                        <span className='line-through text-theme-darkgray'>
                            {`$${base_price}`}
                        </span>
                    )}
                </div>
            </div>
            <div className='flex gap-4 items-center'>
                <div className='w-24 h-8 flex justify-center'>
                    <QuantityButton
                        callback={decrementQuantity}
                        Icon={MinusIcon}
                    />
                    <div className='w-1/3 h-full flex justify-center items-center'>
                        {quantity}
                    </div>
                    <QuantityButton
                        callback={incrementQuantity}
                        Icon={PlusIcon}
                    />
                </div>
                <button
                    onClick={() => addToCart(pk, quantity)}
                    className='uppercase bg-theme-lightcrimson hover:bg-theme-crimson px-8 py-2 rounded-full text-theme-white transition-colors duration-200'
                >
                    Buy
                </button>
            </div>
        </article>
    );
};
