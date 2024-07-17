export type CartItem = {
    pk: number;
    product: {
        name: string;
        price: string;
        image: string;
    };
    quantity: number;
}