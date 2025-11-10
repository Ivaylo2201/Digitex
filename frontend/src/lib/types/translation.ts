export type Translation = {
  products: {
    processors: string;
    graphicsCards: string;
    powerSupplies: string;
    rams: string;
    ssds: string;
    motherboards: string;
    monitors: string;
  };
  user: {
    cart: string;
    account: string;
    wishlist: string;
  };
  auth: {
    signIn: string;
    signOut: string;
    verify: string;
  };
  productSearch: string;
  address: string;
};

export const initialTranslation: Translation = {
  user: {
    cart: 'Cart',
    account: 'Account',
    wishlist: 'Wishlist'
  },
  products: {
    processors: 'Processors',
    graphicsCards: 'Graphics cards',
    powerSupplies: 'Power supplies',
    rams: 'RAMs',
    ssds: 'SSDs',
    motherboards: 'Motherboards',
    monitors: 'Monitors'
  },
  auth: {
    signIn: 'Sign in',
    signOut: 'Sign out',
    verify: ''
  },
  address: 'Sofia, Vitosha Blvd. 76',
  productSearch: 'Search for products...'
};
