import { NavLink } from 'react-router';

type CategoryLinkProps = {
  categoryName: string;
  route: string;
};

export default function CategoryLink({ categoryName, route }: CategoryLinkProps) {
  return (
    <NavLink
      to={`/products/categories${route}`}
      className={({ isActive }) =>
        `transition-colors duration-200 font-semibold py-3.5 px-2 ${
          isActive
            ? 'text-theme-crimson'
            : 'text-theme-gunmetal hover:text-theme-crimson'
        }`
      }
    >
      {categoryName}
    </NavLink>
  );
}
