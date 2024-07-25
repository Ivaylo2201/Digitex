import { NavLink } from 'react-router-dom';

type CategoryLinkProps = {
    to: string;
    label: string;
};

const baseClassName: string = 'text-center block py-4 px-10 font-Montserrat';
const inactiveClassName: string = `${baseClassName} bg-theme-white text-theme-darkgray hover:bg-theme-crimson hover:text-theme-white transition-colors duration-150`;
const activeClassName: string = `${baseClassName} bg-theme-crimson text-theme-white`;

export const CategoryLink = ({
    to,
    label
}: CategoryLinkProps): JSX.Element => {
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
