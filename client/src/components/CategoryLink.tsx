type CategoryLinkProps = {
    to: string;
    label: string;
};

export const CategoryLink = ({
    to,
    label
}: CategoryLinkProps): JSX.Element => {
    return (
        <li>
            <a
                className='text-center block py-4 px-10 font-Montserrat text-theme-darkgray hover:bg-theme-lightcrimson hover:text-theme-white transition-colors duration-150'
                href={to}
            >
                {label}
            </a>
        </li>
    );
};
