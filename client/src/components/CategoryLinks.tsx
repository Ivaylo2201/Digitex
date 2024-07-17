import { CategoryLink } from "./CategoryLink";

export const CategoryLinks = (): JSX.Element => {
    return (
        <nav className='border-b-2 border-theme-gray flex justify-center'>
            <ul className='w-full lg:w-3/5 flex flex-col justify-center lg:flex-row'>
                <CategoryLink to="" label="Home" />
                <CategoryLink to="" label="Smartphones" />
                <CategoryLink to="" label="Tablets" />
                <CategoryLink to="" label="Monitors" />
                <CategoryLink to="" label="TVs" />
                <CategoryLink to="" label="Laptops" />
                <CategoryLink to="" label="Computers" />
                <CategoryLink to="" label="Headsets" />
            </ul>
        </nav>
    );
};
