import { Link } from 'react-router-dom';
import { InformationPanel } from './InformationPanel';
import { useEffect } from 'react';
import { useCart } from '../context/CartContextProvider';
import { AccountButton } from '../auth/AccountButton';
import { CartButton } from '../cart/CartButton';
import { CategoryLinks } from '../navigation/CategoryLinks';

export const Header: React.FC = () => {
    const { fetchCartData } = useCart();

    useEffect(() => {
        fetchCartData();
    }, []);

    return (
        <header className=''>
            <InformationPanel />

            <main className='bg-theme-eerie-black flex justify-center items-center border-b-4 border-theme-crimson'>
                <div className='w-2/3 flex flex-col lg:flex-row lg:justify-evenly'>
                    <section className='flex justify-center items-center pt-6 pb-3 lg:pt-7 lg:pb-7'>
                        <Link
                            to='/'
                            className='uppercase font-Montserrat font-bold text-4xl text-theme-white'
                        >
                            Digite
                            <span className='text-theme-crimson'>X</span>
                        </Link>
                    </section>
                    <section className='flex justify-center items-center pt-3 pb-6 lg:pt-7 lg:pb-7'>
                        <div className='flex gap-8'>
                            <AccountButton />
                            <CartButton />
                        </div>
                    </section>
                </div>
            </main>

            <CategoryLinks />
        </header>
    );
};
