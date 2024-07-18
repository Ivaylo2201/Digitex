import { NavLink } from 'react-router-dom';

type CategoryLinkProps = {
    to: string;
    label: string;
};

const baseClassName: string = 'text-center block py-4 px-10 font-Montserrat';
const inactiveClassName: string = `${baseClassName} bg-theme-white text-theme-darkgray hover:bg-theme-lightcrimson hover:text-theme-white transition-colors duration-150`;
const activeClassName: string = `${baseClassName} bg-theme-lightcrimson text-theme-white`;

export const CategoryLink = ({ to, label }: CategoryLinkProps): JSX.Element => {
    return (
        <li>
            <NavLink
                className={({ isActive }) =>
                    isActive ? activeClassName : inactiveClassName
                }
                to={to}
            >
                {label}
            </NavLink>
        </li>
    );
};
