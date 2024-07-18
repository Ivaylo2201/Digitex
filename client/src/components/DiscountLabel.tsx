export const DiscountLabel = ({ amount }: { amount: number } ) => {
    return (
        <span className={`absolute top-3 left-3 px-5 py-1 rounded bg-theme-crimson text-theme-white font-Montserrat`}>
            {`-${amount}%`}
        </span>
    );
};