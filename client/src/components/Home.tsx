import { Outlet } from 'react-router-dom';
import { Header } from '../components/Header';
import { CartProvider } from '../components/CartContextProvider';
import { Footer } from './Footer';
import { LogProvider } from './LogContextProvider';

export const Home: React.FC = () => {
    return (
        <>
            <CartProvider>
                <LogProvider>
                    <Header />
                    <Outlet />
                </LogProvider>
            </CartProvider>
            <Footer />
        </>
    );
};
