import { CategoryLink } from './CategoryLink';

export const CategoryLinks = (): JSX.Element => {
    return (
        <nav className='border-b-2 border-theme-gray flex justify-center'>
            <ul className='w-full lg:w-3/5 flex flex-col justify-center lg:flex-row'>
                <CategoryLink to='/' label='Discounted' />
                <CategoryLink
                    to='/products/smartphones'
                    label='Smartphones'
                />
                <CategoryLink to='/products/tablets' label='Tablets' />
                <CategoryLink to='/products/monitors' label='Monitors' />
                <CategoryLink to='/products/tvs' label='TVs' />
                <CategoryLink to='/products/laptops' label='Laptops' />
                <CategoryLink to='/products/computers' label='Computers' />
                <CategoryLink to='/products/headsets' label='Headsets' />
            </ul>
        </nav>
    );
};
