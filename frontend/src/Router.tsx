import { BrowserRouter, Route, Routes } from 'react-router';
import { AuthenticationRequired } from '@/features/auth/components/AuthenticationRequired';
import { AccountPage } from '@/features/account/pages/AccountPage';
import { FavoritesPage } from '@/features/favorites/pages/FavoritesPage';
import { SignInPage } from '@/features/auth/pages/SignInPage';
import { SignUpPage } from '@/features/auth/pages/SignUpPage';
import { Page } from '@/components/layout/Page';
import { ProductsPage } from '@/features/products/pages/ProductsPage/ProductsPage';
import { CartPage } from './features/cart/pages/CartPage';
import { ComparePage } from './features/compare/pages/ComparePage';
import { ProductPageResolver } from './features/products/pages/ProductPage/ProductPageResolver';
import { AccountVerificationPage } from './features/account/pages/AccountVerificationPage';
import { RequestPasswordResetPage } from './features/account/pages/RequestPasswordResetPage';
import { CompletePasswordResetPage } from './features/account/pages/CompletePasswordResetPage';

export function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Page></Page>} />

        <Route path='/products'>
          <Route path='categories/:category' element={<ProductsPage />} />
          <Route path=':category/:id' element={<ProductPageResolver />} />
        </Route>

        <Route path='/account'>
          <Route
            index
            element={
              <AuthenticationRequired>
                <AccountPage />
              </AuthenticationRequired>
            }
          />
          <Route
            path='verify'
            element={<AccountVerificationPage />} />
          <Route
            path='request-password-reset'
            element={<RequestPasswordResetPage />}
          />
          <Route
            path='complete-password-reset'
            element={<CompletePasswordResetPage />}
          />
        </Route>

        <Route path='/auth'>
          <Route path='sign-in' element={<SignInPage />} />
          <Route path='sign-up' element={<SignUpPage />} />
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
