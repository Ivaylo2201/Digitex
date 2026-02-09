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
import { CheckoutPage } from './features/checkout/pages/CheckoutPage';
import { ThankYouPage } from './features/checkout/pages/ThankYouPage';
import { AdminRequired } from './features/auth/components/AdminRequired';
import { GraphicsCardsAdminPage } from './features/admin/pages/GraphicsCardsAdminPage';
import { OrdersPage } from './features/orders/pages/OrdersPage';
import { MotherboardsAdminPage } from './features/admin/pages/MotherboardsAdminPage';
import { ProcessorsAdminPage } from './features/admin/pages/ProcessorsAdminPage';
import { MonitorsAdminPage } from './features/admin/pages/MonitorsAdminPage';
import { RamsAdminPage } from './features/admin/pages/RamsAdminPage';
import { SsdsAdminPage } from './features/admin/pages/SsdsAdminPage';
import { PowerSuppliesAdminPage } from './features/admin/pages/PowerSuppliesAdminPage';

export function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Page></Page>} />

        <Route path='/admin'>
          <Route
            path='graphics-cards'
            element={
              <AdminRequired>
                <GraphicsCardsAdminPage />
              </AdminRequired>
            }
          />
          <Route
            path='motherboards'
            element={
              <AdminRequired>
                <MotherboardsAdminPage />
              </AdminRequired>
            }
          />
          <Route
            path='processors'
            element={
              <AdminRequired>
                <ProcessorsAdminPage />
              </AdminRequired>
            }
          />
          <Route
            path='monitors'
            element={
              <AdminRequired>
                <MonitorsAdminPage />
              </AdminRequired>
            }
          />
          <Route
            path='rams'
            element={
              <AdminRequired>
                <RamsAdminPage />
              </AdminRequired>
            }
          />
          <Route
            path='ssds'
            element={
              <AdminRequired>
                <SsdsAdminPage />
              </AdminRequired>
            }
          />
          <Route
            path='power-supplies'
            element={
              <AdminRequired>
                <PowerSuppliesAdminPage />
              </AdminRequired>
            }
          />
        </Route>

        <Route path='/products'>
          <Route path='categories/:category' element={<ProductsPage />} />
          <Route path=':category/:id' element={<ProductPageResolver />} />
        </Route>

        <Route path='/orders' element={<OrdersPage />} />

        <Route path='/account'>
          <Route
            index
            element={
              <AuthenticationRequired>
                <AccountPage />
              </AuthenticationRequired>
            }
          />
          <Route path='verify' element={<AccountVerificationPage />} />
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
          path='/checkout'
          element={
            <AuthenticationRequired>
              <CheckoutPage />
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

        <Route
          path='/thank-you'
          element={
            <AuthenticationRequired>
              <ThankYouPage />
            </AuthenticationRequired>
          }
        />
      </Routes>
    </BrowserRouter>
  );
}
