type CartItemsCounterProps = {
    count: number;
};

export const CartItemsCounter = ({ count }: CartItemsCounterProps) => {
    return (
        <>
            {count > 0 && (
                <span className='w-5 h-5 flex justify-center items-center absolute -top-2 -right-1 rounded-full bg-theme-crimson text-xs text-theme-white font-Montserrat '>
                    {count}
                </span>
            )}
        </>
    );
};
