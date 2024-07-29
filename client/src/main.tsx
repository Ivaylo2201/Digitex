import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';

import { ProductsList } from './components/ProductsList.tsx';
import { Home } from './components/Home.tsx';
import { SignInForm } from './components/SignInForm.tsx';
import { SignUpForm } from './components/SignUpForm.tsx';

const router = createBrowserRouter([
    {
        path: '/',
        element: <Home />,
        children: [
            {
                path: '/',
                element: <ProductsList category='discounted' />
            },
            {
                path: '/products/smartphones',
                element: <ProductsList category='smartphones' />
            },
            {
                path: '/products/tablets',
                element: <ProductsList category='tablets' />
            },
            {
                path: '/products/monitors',
                element: <ProductsList category='monitors' />
            },
            {
                path: '/products/tvs',
                element: <ProductsList category='tvs' />
            },
            {
                path: '/products/laptops',
                element: <ProductsList category='laptops' />
            },
            {
                path: '/products/computers',
                element: <ProductsList category='computers' />
            },
            {
                path: '/products/headsets',
                element: <ProductsList category='headsets' />
            },
            {
                path: '/accounts/signin',
                element: <SignInForm />
            },
            {
                path: '/accounts/signup',
                element: <SignUpForm />
            }
        ]
    }
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <RouterProvider router={router} />
    </React.StrictMode>
);
