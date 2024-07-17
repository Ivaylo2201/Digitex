import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import {
    createBrowserRouter,
    RouterProvider
} from 'react-router-dom';
import { Home } from './pages/Home.tsx';

const router = createBrowserRouter([
    {
        path: '/',
        element: <Home />,
        children: [
            {
                path: '/',
                element: <h2>Discounted</h2>
            },
            {
                path: '/products/smartphones'
            },
            {
                path: '/products/tablets'
            },
            {
                path: '/products/monitors'
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
