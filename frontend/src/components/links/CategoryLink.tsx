import { NavLink } from 'react-router';

type CategoryLinkProps = {
  category: string;
  to: string;
};

export default function CategoryLink({ category, to }: CategoryLinkProps) {
  return (
    <NavLink
      to={`/products/${to}`}
      className={({ isActive }) =>
        `transition-colors duration-200 font-semibold ${
          isActive
            ? 'text-theme-crimson'
            : 'text-theme-gunmetal hover:text-theme-crimson'
        }`
      }
    >
      {category}
    </NavLink>
  );
}
