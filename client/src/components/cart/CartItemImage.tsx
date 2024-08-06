type CartItemImage = {
    image: string;
};

export const CartItemImage = ({ image }: CartItemImage) => {
    return (
        <>
            <div className='w-16 flex items-center'>
                <img src={image} alt='' />
            </div>
        </>
    );
};
