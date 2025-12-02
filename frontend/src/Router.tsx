import { BrowserRouter, Route, Routes } from 'react-router';
import { AuthenticationRequired } from '@/features/auth/components/AuthenticationRequired';
import { AccountPage } from '@/features/account/pages/AccountPage';
import { FavoritesPage } from '@/features/favorites/pages/FavoritesPage';
import { SignInPage } from '@/features/auth/pages/SignInPage';
import { SignUpPage } from '@/features/auth/pages/SignUpPage';
import { Page } from '@/components/layout/Page';
import { ProductsPage } from '@/features/products/pages/ProductsPage/ProductsPage';
import { AccountVerifiedPage } from './features/account/pages/AccountVerifiedPage';
import { CartPage } from './features/cart/pages/CartPage';
import { ComparePage } from './features/compare/pages/ComparePage';
import { ProductPageResolver } from './features/products/pages/ProductPage/ProductPageResolver';

export function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Page></Page>} />

        <Route
          path='/products/categories/:category'
          element={<ProductsPage />}
        />

        <Route
          path='/products/:category/:id'
          element={<ProductPageResolver />}
        />

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
          <Route path='verify' element={<AccountVerifiedPage />} />
        </Route>
        <Route path='/compare' element={<ComparePage />} />
        <Route
          path='/cart'
          element={
            <AuthenticationRequired>
              <CartPage />
            </AuthenticationRequired>
          }
        />
        <Route
          path='/favorites'
          element={
            <AuthenticationRequired>
              <FavoritesPage />
            </AuthenticationRequired>
          }
        />
      </Routes>
    </BrowserRouter>
  );
}
