import { BrowserRouter, Route, Routes } from "react-router";
import AuthenticationRequired from "@/components/auth/AuthenticationRequired";
import AccountPage from "@/components/pages/AccountPage";
import WishlistPage from "@/components/pages/WishlistPage";
import SignInPage from "@/components/pages/SignInPage";
import SignUpPage from "@/components/pages/SignUpPage";
import Page from "@/components/pages/base/Page";
import ProductsPage from "@/components/pages/ProductsPage";
import AccountVerifiedPage from "./pages/AccountVerifiedPage";
import CartPage from "./pages/CartPage";
import ProcessorProductPage from "./pages/products/ProcessorProductPage";
import GraphicsCardProductPage from "./pages/products/GraphicsCardProductPage";
import MonitorProductPage from "./pages/products/MonitorProductPage";
import MotherboardProductPage from "./pages/products/MotherboardProductPage";
import PowerSupplyProductPage from "./pages/products/PowerSupplyProductPage";
import RamProductPage from "./pages/products/RamProductPage";
import SsdProductPage from "./pages/products/SsdProductPage";

export default function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Page></Page>} />

        <Route
          path='/products/categories/:category'
          element={<ProductsPage />}
        />

        <Route
          path='/products/processors/:id'
          element={<ProcessorProductPage />}
        />
        <Route
          path='/products/graphics-cards/:id'
          element={<GraphicsCardProductPage />}
        />
        <Route
          path='/products/monitors/:id'
          element={<MonitorProductPage />}
        />
        <Route
          path='/products/power-supplies/:id'
          element={<PowerSupplyProductPage />}
        />
        <Route
          path='/products/motherboards/:id'
          element={<MotherboardProductPage />}
        />
        
        <Route path='/products/rams/:id' element={<RamProductPage />} />
        <Route path='/products/ssds/:id' element={<SsdProductPage />} />

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
