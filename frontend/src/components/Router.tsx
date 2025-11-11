import { BrowserRouter, Route, Routes } from "react-router";
import AuthenticationRequired from "@/components/auth/AuthenticationRequired";
import AccountPage from "@/components/pages/AccountPage";
import WishlistPage from "@/components/pages/WishlistPage";
import SignInPage from "@/components/pages/SignInPage";
import SignUpPage from "@/components/pages/SignUpPage";
import Page from "@/components/pages/Page";
import ProductsPage from "@/components/pages/ProductsPage";
import AccountVerifiedPage from "./pages/AccountVerifiedPage";
import CartPage from "./pages/CartPage";
import ProductPage from "./pages/ProductPage";

export default function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Page></Page>} />
        <Route path='/products/:category/:id' element={<ProductPage />} />
        <Route
          path='/products/categories/:category'
          element={<ProductsPage />}
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
        <Route
          path='/cart'
          element={
            <AuthenticationRequired>
              <CartPage />
            </AuthenticationRequired>
          }
        />
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
