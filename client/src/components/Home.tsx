import { Outlet } from 'react-router-dom';
import { Header } from '../components/Header';
import { CartProvider } from '../components/CartContextProvider';
import { Footer } from './Footer';

export const Home = (): JSX.Element => {
    return (
        <>
            <CartProvider>
                <Header />
                <Outlet />
            </CartProvider>
            <Footer />
        </>
    );
};
