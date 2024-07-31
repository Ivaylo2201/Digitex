import { Outlet } from 'react-router-dom';
import { CartProvider } from '../context/CartContextProvider';
import { LogProvider } from '../context/LogContextProvider';
import { Header } from '../layout/Header';
import { Footer } from '../layout/Footer';


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
