import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import {
    createBrowserRouter,
    RouterProvider
} from 'react-router-dom';

import { ProductsList } from './components/ProductsList.tsx';
import { Home } from './components/Home.tsx';

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
                path: '/products/tablets'
            },
            {
                path: '/products/monitors',
                element: <ProductsList category='monitors' />
            },
            {
                path: '/products/tvs'
            },
            {
                path: '/products/laptops'
            },
            {
                path: '/products/computers'
            },
            {
                path: '/products/headsets'
            }
        ]
    }
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <RouterProvider router={router} />
    </React.StrictMode>
);
