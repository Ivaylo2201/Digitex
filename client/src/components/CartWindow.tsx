import laptop from '../assets/laptop.png';
import smartphone from '../assets/smartphone.jpg';
import { CartItem } from './CartItem';

export const CartWindow = (): JSX.Element => {
    return (
        <section className='absolute top-16 rounded-sm p-3 flex flex-col gap-2 bg-theme-white border border-theme-gray'>
            <>
                <CartItem
                    productName={'Laptop Lenovo 1234'}
                    productPrice={'980.00'}
                    productImage={laptop}
                    quantity={2}
                />
                <CartItem
                    productName={'Samsung Galaxy S24 Ultra'}
                    productPrice={'1250.00'}
                    productImage={smartphone}
                    quantity={6}
                />
            </>
            <div className='flex flex-col mx-1 font-Montserrat'>
                <hr className='bg-theme-gray' />
                <div className='flex justify-between items-center mt-3'>
                    <div>
                        <p className='text-xm text-theme-darkgray'>
                            2 Item(s) selected
                        </p>
                        <p className='uppercase text-theme-darkblue font-bold text-2xm'>
                            Subtotal: $25940.00
                        </p>
                    </div>
                    <button className='text-xm uppercase bg-theme-lightcrimson hover:bg-theme-crimson text-theme-white rounded-full px-7 py-2 mr-1 transition-colors duration-150'>
                        Buy
                    </button>
                </div>
            </div>
        </section>
    );
};
