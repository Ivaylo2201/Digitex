import { BrowserRouter, Route, Routes } from 'react-router';
import AuthenticationRequired from '@/components/auth/AuthenticationRequired';
import AccountPage from '@/components/pages/AccountPage';
import WishlistPage from '@/components/pages/WishlistPage';
import SignInPage from '@/components/pages/SignInPage';
import SignUpPage from '@/components/pages/SignUpPage';
import Page from '@/components/pages/Page';
import ProductCard from '@/components/shared/productCard/ProductCard';
import a from '@/assets/a.png';
import ProductsPage from './pages/ProductsPage';

export default function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Page></Page>} />
        <Route path='/products/category/:category' element={<ProductsPage />} />
        <Route path='/products/:id' element={<Page />} />
        <Route path='/auth'>
          <Route
            path='account'
            element={
              <AuthenticationRequired>
                <AccountPage />
              </AuthenticationRequired>
            }
          />
          <Route path='sign-in' element={<SignInPage />} />
          <Route path='sign-up' element={<SignUpPage />} />
        </Route>
        <Route
          path='/wishlist'
          element={
            <AuthenticationRequired>
              <WishlistPage />
            </AuthenticationRequired>
          }
        />
      </Routes>
    </BrowserRouter>
  );
}
