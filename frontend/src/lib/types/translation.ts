export type Translation = {
  address: string;
  cart: string;
  account: string;
  productSearch: string;
  wishlist: string;
  processors: string;
  graphicCards: string;
  powerSupplies: string;
  rams: string;
  ssds: string;
  motherboards: string;
  monitors: string;
};

export const initialTranslation: Translation = {
  address: 'Sofia, Vitosha Blvd. 76',
  cart: 'Cart',
  account: 'Account',
  productSearch: 'Search for products...',
  wishlist: 'Wishlist',
  processors: 'Processors',
  graphicCards: 'Graphic cards',
  powerSupplies: 'Power supplies',
  rams: 'RAMs',
  ssds: 'SSDs',
  motherboards: 'Motherboards',
  monitors: 'Monitors'
};
