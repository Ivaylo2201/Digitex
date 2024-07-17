import { CartItem } from '../types/CartItem';
import { CartItemCard } from './CartItemCard';

type ItemList = {
    items: CartItem[];
};

export const CardItemCardList = ({
    items
}: ItemList): JSX.Element => {
    return (
        <>
            {items.map((item, i) => {
                return (
                    <CartItemCard
                        key={i}
                        pk={item.pk}
                        product={item.product}
                        quantity={item.quantity}
                    />
                );
            })}
        </>
    );
};
