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
        passwordContainsUsername: string;
      };
      username: {
        requiredError: string;
        minLengthError: string;
        maxLengthError: string;
      };
    };
  };
  components: {
    chatbot: {
      typeYourMessage: string;
    }
    footer: {
      allRightsReserved: string;
    };
    filterForm: {
      brand: string;
      price: string;
      apply: string;
    };
    graphicsCardsFilterForm: {
      busWidth: string;
      memoryCapacity: string;
      clockSpeed: string;
      cudaCores: string;
    };
    motherboardsFilterForm: {
      socket: string;
      formFactor: string;
      chipset: string;
    };
    processorsFilterForm: {
      cores: string;
      threads: string;
      socket: string;
      tdp: string;
    };
    powerSuppliesFilterForm: {
      formFactor: string;
      efficiencyPercentage: string;
      modularity: string;
    };
    ramsFilterForm: {
      memoryCapacity: string;
      memoryType: string;
      frequency: string;
    };
    ssdsFilterForm: {
      memoryCapacity: string;
      storageInterface: string;
      readSpeed: string;
      writeSpeed: string;
    };
    monitorsFilterForm: {
      refreshRates: string;
      matrices: string;
      resolutionTypes: string;
    };
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
    productPage: {
      sku: string;
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
    emptyMessagesSection: {
      hiThereImYourDigitexAssistant: string;
      imHereToHelpAskMeAnything: string;
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
      forgotPassword: string;
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
    completePasswordResetForm: {
      completePasswordReset: string;
      enterYourNewPasswordBelow: string;
      newPassword: string;
      newPasswordConfirmation: string;
    };
    requestPasswordResetForm: {
      enterYourEmailToRequestAPasswordResetForYourAccount: string;
      email: string;
      requestAPasswordReset: string;
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
    gigahertz: string;
    watts: string;
    bits: string;
    mbPerSecond: string;
    milliseconds: string;
    millimeters: string;
    nits: string;
  };
  hooks: {
    useAddToCart: {
      productSuccessfullyAddedToCart: string;
    };
    useSignUp: {
      visitYourEmailToVerifyYourAccount: string;
    };
    useForgotPassword: {
      visitYourEmailToResetYourPassword: string;
    };
    generic: {
      somethingWentWrong: string;
    };
    useSignIn: {
      invalidCredentials: string;
    };
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
        passwordContainsUsername: 'Password cannot contain the username.',
      },
      username: {
        requiredError: 'Username is required.',
        minLengthError: 'Username is too short.',
        maxLengthError: 'Username is too long.',
      },
    },
  },
  components: {
    chatbot: {
      typeYourMessage: 'Type your message...',
    },
    emptyMessagesSection: {
      hiThereImYourDigitexAssistant: "Hi there! I'm your Digitex assistant",
      imHereToHelpAskMeAnything: "I'm here to help - Ask me anything!",
    },
    footer: {
      allRightsReserved: 'All rights reserved.',
    },
    filterForm: {
      brand: 'Brand',
      price: 'Price',
      apply: 'Apply',
    },
    processorsFilterForm: {
      cores: 'Cores',
      threads: 'Threads',
      socket: 'Socket',
      tdp: 'TDP',
    },
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
    productPage: {
      sku: 'SKU',
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
      forgotPassword: 'Forgot password?',
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
    completePasswordResetForm: {
      completePasswordReset: 'Complete password reset',
      enterYourNewPasswordBelow: 'Enter your new password below.',
      newPassword: 'New password',
      newPasswordConfirmation: 'New password confirmation',
    },
    requestPasswordResetForm: {
      enterYourEmailToRequestAPasswordResetForYourAccount:
        'Enter your email to request a password reset for your account.',
      email: 'Email',
      requestAPasswordReset: 'Request a password reset',
    },
    graphicsCardsFilterForm: {
      busWidth: 'Bus width',
      memoryCapacity: 'Memory capacity',
      clockSpeed: 'Clock speed',
      cudaCores: 'CUDA cores',
    },
    motherboardsFilterForm: {
      socket: 'Socket',
      formFactor: 'Form factor',
      chipset: 'Chipset',
    },
    powerSuppliesFilterForm: {
      formFactor: 'Form factor',
      efficiencyPercentage: 'Efficiency percentage',
      modularity: 'Modularity',
    },
    ramsFilterForm: {
      memoryCapacity: 'Memory capacity',
      memoryType: 'Memory type',
      frequency: 'Frequency',
    },
    ssdsFilterForm: {
      memoryCapacity: 'Memory capacity',
      storageInterface: 'Storage interface',
      readSpeed: 'Read speed',
      writeSpeed: 'Write speed',
    },
    monitorsFilterForm: {
      refreshRates: 'Refresh rates',
      matrices: 'Matrices',
      resolutionTypes: 'Resolution types',
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
    gigahertz: 'GHz',
    watts: 'W',
    bits: 'bits',
    mbPerSecond: 'MB/s',
    milliseconds: 'ms',
    millimeters: 'mm',
    nits: 'nits',
  },
  hooks: {
    useSignUp: {
      visitYourEmailToVerifyYourAccount:
        'Visit your email to verify your account.',
    },
    useForgotPassword: {
      visitYourEmailToResetYourPassword:
        'Visit your email to reset your password.',
    },
    generic: { somethingWentWrong: 'Something went wrong.' },
    useAddToCart: {
      productSuccessfullyAddedToCart: 'Product successfully added to cart.',
    },
    useSignIn: {
      invalidCredentials: 'Invalid credentials.',
    },
  },
};
