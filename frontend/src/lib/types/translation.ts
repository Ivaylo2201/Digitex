export type Translation = {
  products: {
    mainSpecifications: string
    monitors: {
      category: string;
      specs: {
        displayDiagonal: string;
        refreshRate: string;
        latency: string;
        matrix: string;
        resolution: string;
        pixelSize: string;
        brightness: string;
        colorSpectre: string;
      };
    };
    graphicsCards: string;
    powerSupplies: string;
    rams: string;
    ssds: string;
    motherboards: string;
    processors: string;
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
    mainSpecifications: "Main specification",
    monitors: {
      category: "Monitors",
      specs: {
        displayDiagonal: "Display diagonal",
        refreshRate: "Refresh rate",
        latency: "Latency",
        matrix: "Matrix",
        resolution: "Resolution",
        pixelSize: "Pixel size",
        brightness: "Brightness",
        colorSpectre: "Color spectre"
      }
    },
    graphicsCards: 'Graphics cards',
    powerSupplies: 'Power supplies',
    rams: 'RAMs',
    ssds: 'SSDs',
    motherboards: 'Motherboards',
    processors: 'Processors'
  },
  auth: {
    signIn: 'Sign in',
    signOut: 'Sign out',
    verify: ''
  },
  address: 'Sofia, Vitosha Blvd. 76',
  productSearch: 'Search for products...'
};
