import { useCart } from '../context/CartContextProvider';
import { CartItemCardList } from './CartItemCardList';
import { NoCartItems } from './NoCartItems';

export const CartWindow: React.FC = () => {
    const { placeOrder, cartData } = useCart();

    return (
        <section className='absolute z-50 -left-40 lg:-left-0 top-16 rounded-sm p-3 flex flex-col gap-2 bg-theme-white border border-theme-gray'>
            <>
                {cartData.cartitems_count > 0 ? (
                    <CartItemCardList items={cartData.cartitems} />
                ) : (
                    <NoCartItems />
                )}
            </>
            <div className='flex flex-col mx-1 font-Montserrat'>
                <hr className='bg-theme-gray' />
                <div className='flex justify-between items-center mt-3'>
                    <div>
                        <p className='text-xm text-theme-darkgray'>
                            {`${cartData.cartitems_count} Item(s) selected`}
                        </p>
                        <p className='uppercase text-theme-darkblue font-bold text-2xm'>
                            {`Subtotal: $${cartData.subtotal}`}
                        </p>
                    </div>
                    <button
                        onClick={placeOrder}
                        className='text-xm uppercase bg-theme-crimson hover:bg-theme-lightcrimson text-theme-white rounded-full px-5 py-2 mr-1 transition-colors duration-150'
                    >
                        Order
                    </button>
                </div>
            </div>
        </section>
    );
};
