import { CartItem } from '../types/CartItem';
import { CartItemCard } from './CartItemCard';

export const CardItemCardList = ({ items }: { items: CartItem[] }): JSX.Element => {
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
