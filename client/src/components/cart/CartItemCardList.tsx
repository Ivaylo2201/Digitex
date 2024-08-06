import { CartItem } from '../../types/CartItem';
import { CartItemCard } from './CartItemCard';

type CartItemCardListProps = {
    items: CartItem[];
};

export const CartItemCardList = ({ items }: CartItemCardListProps) => {
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
