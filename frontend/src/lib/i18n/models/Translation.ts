export type Translation = {
  validationSchemas: {
    auth: {
      email: {
        requiredError: string;
        invalidEmailError: string;
      };
      password: {
        requiredError: string;
        minLengthError: string;
        regexError: string;
        passwordMismatchError: string;
      };
      username: {
        requiredError: string;
        minLengthError: string;
        maxLengthError: string;
      };
    };
  };
  components: {
    header: {
      merchantAddress: string;
    };
    searchBox: {
      searchForProducts: string;
    };
    accountLink: {
      account: string;
    };
    signInLink: {
      signIn: string;
    };
    signOutButton: {
      signOut: string;
    };
    cartLink: {
      cart: string;
    };
    compareLink: {
      compare: string;
    };
    emptyComparePage: {
      noProductsAddedForComparison: string;
      youHaveNotAddedAnyProductsForComparisonYet: string;
      getStartedByAddingAProduct: string;
      addProducts: string;
    };
    accountVerifiedPage: {
      accountVerifiedSuccessfully: string;
      accountVerificationFailed: string;
    };
    emptySuggestedProductsSection: {
      noSuggestedProductsAvailable: string;
      thisProductHasNoSuggestionsYet: string;
    };
    emptyReviewsSection: {
      noReviewsForThisProduct: string;
      noReviewsHaveBeenLeftForThisProductYet: string;
      writeTheFirstReviewViaTheFormBelow: string;
    };
    favoritesLink: {
      favorites: string;
    };
    productPageBreadcrumb: {
      home: string;
    };
    addToCompareButton: {
      maxComparisonCapacityReached: string;
      incompatibleComparisonCategory: string;
      productAlreadyAddedToComparison: string;
      productSuccessfullyAddedToComparison: string;
    };
    //addToFavoritesButton: {};
    productCompareTable: {
      comparedProducts: string;
    };
    specificationsTable: {
      mainSpecifications: string;
    };
    addToCartButton: {
      addToCart: string;
      outOfStock: string;
    };
    suggestedProductsSection: {
      suggestedProducts: string;
      noSuggestedProductsAvailable: string;
      thisProductHasNoSuggestionsYet: string;
    };
    reviewsSection: {
      reviews: string;
      noReviewsForThisProduct: string;
      noReviewsHaveBeenLeftForThisProductYet: string;
      writeTheFirstReviewViaTheFormBelow: string;
    };
    loader: {
      loading: string;
    };
    signInForm: {
      signInToYourAccount: string;
      enterYourCredentialsToSignInToYourAccount: string;
      email: string;
      password: string;
      signIn: string;
      dontHaveAnAccount: string;
      signUp: string;
      rememberMe: string;
    };
    signUpForm: {
      createdAnAccount: string;
      enterYourCredentialsToSignUpForAnAccount: string;
      email: string;
      username: string;
      password: string;
      passwordConfirmation: string;
      signUp: string;
      alreadyHaveAnAccount: string;
      signIn: string;
      acceptTermsAndConditions: string;
    };
  };
  specifications: {
    base: {
      brand: string;
      model: string;
      image: string;
      price: string;
    };
    monitors: {
      displayDiagonal: string;
      refreshRate: string;
      latency: string;
      matrix: string;
      resolution: string;
      pixelSize: string;
      brightness: string;
      colorSpectre: string;
    };
    processors: {
      cores: string;
      threads: string;
      baseClockSpeed: string;
      boostClockSpeed: string;
      socket: string;
      tdp: string;
    };
    graphicsCards: {
      memory: string;
      baseClockSpeed: string;
      boostClockSpeed: string;
      busWidth: string;
      cudaCores: string;
      directXSupport: string;
      tdp: string;
    };
    motherboards: {
      socket: string;
      formFactor: string;
      chipset: string;
      ramSlots: string;
      pcieSlots: string;
    };
    powerSupplies: {
      wattage: string;
      formFactor: string;
      efficiencyPercentage: string;
      modularity: Record<string, string>;
    };
    rams: {
      memory: string;
      timing: string;
    };
    ssds: {
      capacityInGb: string;
      operationSpeedRead: string;
      operationSpeedWrite: string;
      interface: string;
    };
  };
  routeNames: {
    monitors: 'Monitors';
    'graphics-cards': 'Graphics cards';
    'power-supplies': 'Power supplies';
    rams: 'RAMs';
    ssds: 'SSDs';
    motherboards: 'Motherboards';
    processors: 'Processors';
    home: 'Home';
  };
  units: {
    gigabytes: string;
    hertz: string;
    megahertz: string;
    watts: string;
    bits: string;
    mbPerSecond: string;
    milliseconds: string;
    millimeters: string;
    nits: string;
  };
  generic: {
    somethingWentWrong: string;
  };
};

export const translation: Translation = {
  validationSchemas: {
    auth: {
      email: {
        requiredError: 'Email is required.',
        invalidEmailError: 'Invalid email address.',
      },
      password: {
        requiredError: 'Password is required.',
        minLengthError: 'Password is too short.',
        regexError: 'Password does not meet complexity requirements.',
        passwordMismatchError: 'Passwords do not match.',
      },
      username: {
        requiredError: 'Username is required.',
        minLengthError: 'Username is too short.',
        maxLengthError: 'Username is too long.',
      },
    },
  },
  components: {
    header: {
      merchantAddress: 'Sofia, Vitosha Blvd. 76',
    },
    searchBox: {
      searchForProducts: 'Search for products...',
    },
    accountLink: {
      account: 'Account',
    },
    signInLink: {
      signIn: 'Sign in',
    },
    signOutButton: {
      signOut: 'Sign out',
    },
    cartLink: {
      cart: 'Cart',
    },
    compareLink: {
      compare: 'Compare',
    },
    productCompareTable: {
      comparedProducts: 'Compared Products',
    },
    emptyComparePage: {
      noProductsAddedForComparison: 'No products added for comparison',
      youHaveNotAddedAnyProductsForComparisonYet:
        "You haven't added any products for comparison yet.",
      getStartedByAddingAProduct: 'Get started by adding a product.',
      addProducts: 'Add products',
    },
    emptySuggestedProductsSection: {
      noSuggestedProductsAvailable: 'No suggested products available',
      thisProductHasNoSuggestionsYet: 'This product has no suggestions yet',
    },
    emptyReviewsSection: {
      noReviewsForThisProduct: 'No reviews for this product',
      noReviewsHaveBeenLeftForThisProductYet:
        'No reviews have been left for this product yet',
      writeTheFirstReviewViaTheFormBelow:
        'Write the first review via the form below',
    },
    favoritesLink: {
      favorites: 'Favorites',
    },
    productPageBreadcrumb: {
      home: 'Home',
    },
    addToCompareButton: {
      maxComparisonCapacityReached: 'Max compare capacity reached.',
      incompatibleComparisonCategory: 'Incompatible comparison category.',
      productAlreadyAddedToComparison: 'Product already present in comparison.',
      productSuccessfullyAddedToComparison: 'Product added to comparison.',
    },
    //addToFavoritesButton: {},
    specificationsTable: {
      mainSpecifications: 'Main specifications',
    },
    addToCartButton: {
      addToCart: 'Add to cart',
      outOfStock: 'Out of stock',
    },
    suggestedProductsSection: {
      suggestedProducts: 'Suggested products',
      noSuggestedProductsAvailable: 'No suggested products available',
      thisProductHasNoSuggestionsYet: 'This product has no suggestions yet',
    },
    reviewsSection: {
      reviews: 'Reviews',
      noReviewsForThisProduct: 'No reviews for this product',
      noReviewsHaveBeenLeftForThisProductYet:
        'No reviews have been left for this product yet',
      writeTheFirstReviewViaTheFormBelow:
        'Write the first review via the form below',
    },
    loader: {
      loading: 'Loading',
    },
    signInForm: {
      signInToYourAccount: 'Sign in to your account',
      enterYourCredentialsToSignInToYourAccount:
        'Enter your credentials to sign in to your account.',
      email: 'Email',
      password: 'Password',
      signIn: 'Sign in',
      dontHaveAnAccount: "Don't have an account?",
      signUp: 'Sign up',
      rememberMe: 'Remember me',
    },
    signUpForm: {
      createdAnAccount: 'Create an account',
      enterYourCredentialsToSignUpForAnAccount:
        'Enter your credentials to sign up for an account.',
      email: 'Email',
      username: 'Username',
      password: 'Password',
      passwordConfirmation: 'Password confirmation',
      signUp: 'Sign up',
      alreadyHaveAnAccount: 'Already have an account?',
      signIn: 'Sign in',
      acceptTermsAndConditions: 'I accept the Terms and Conditions',
    },
    accountVerifiedPage: {
      accountVerifiedSuccessfully: 'Account verified successfully.',
      accountVerificationFailed: 'Account verification failed.',
    },
  },
  specifications: {
    base: {
      brand: 'Brand',
      model: 'Model',
      image: 'Image',
      price: 'Price',
    },
    monitors: {
      displayDiagonal: 'Display diagonal',
      refreshRate: 'Refresh rate',
      latency: 'Latency',
      matrix: 'Matrix',
      resolution: 'Resolution',
      pixelSize: 'Pixel size',
      brightness: 'Brightness',
      colorSpectre: 'Color spectre',
    },
    processors: {
      cores: 'Cores',
      threads: 'Threads',
      baseClockSpeed: 'Base clock speed',
      boostClockSpeed: 'Boost clock speed',
      socket: 'Socket',
      tdp: 'TDP',
    },
    graphicsCards: {
      memory: 'Memory',
      baseClockSpeed: 'Base clock speed',
      boostClockSpeed: 'Boost clock speed',
      busWidth: 'Bus width',
      cudaCores: 'CUDA cores',
      directXSupport: 'DirectX support',
      tdp: 'TDP',
    },
    motherboards: {
      socket: 'Socket',
      formFactor: 'Form factor',
      chipset: 'Chipset',
      ramSlots: 'RAM slots',
      pcieSlots: 'PCIe slots',
    },
    powerSupplies: {
      wattage: 'Wattage',
      formFactor: 'Form factor',
      efficiencyPercentage: 'Efficiency percentage',
      modularity: {
        label: 'Modularity',
        none: 'None',
        semi: 'Semi',
        full: 'Full',
      },
    },
    rams: {
      memory: 'Memory',
      timing: 'Timing',
    },
    ssds: {
      capacityInGb: 'Capacity',
      operationSpeedRead: 'Read speed',
      operationSpeedWrite: 'Write speed',
      interface: 'Interface',
    },
  },
  routeNames: {
    monitors: 'Monitors',
    processors: 'Processors',
    'graphics-cards': 'Graphics cards',
    motherboards: 'Motherboards',
    'power-supplies': 'Power supplies',
    rams: 'RAMs',
    ssds: 'SSDs',
    home: 'Home',
  },
  units: {
    gigabytes: 'GB',
    hertz: 'Hz',
    megahertz: 'MHz',
    watts: 'W',
    bits: 'bits',
    mbPerSecond: 'MB/s',
    milliseconds: 'ms',
    millimeters: 'mm',
    nits: 'nits',
  },
  generic: {
    somethingWentWrong: 'Something went wrong.',
  },
};
