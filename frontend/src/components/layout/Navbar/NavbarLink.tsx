import { NavLink } from 'react-router';

type NavbarLinkProps = {
  to: string;
  content: string;
};

export function NavbarLink({ to, content }: NavbarLinkProps) {
  return (
    <NavLink
      to={`/products/categories${to}`}
      className={({ isActive }) =>
        `transition-colors duration-200 font-semibold py-3.5 px-2 ${
          isActive
            ? 'text-theme-crimson'
            : 'text-theme-gunmetal hover:text-theme-crimson'
        }`
      }
    >
      {content}
    </NavLink>
  );
}
