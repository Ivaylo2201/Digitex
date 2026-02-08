export type Translation = {
  validationSchemas: {
    baseForm: {
      brandId: {
        requiredError: string;
        nonNegativeError: string;
      };
      modelName: {
        requiredError: string;
        minLengthError: string;
      };
      price: {
        requiredError: string;
        nonNegativeError: string;
      };
      discountPercentage: {
        requiredError: string;
        minError: string;
        maxError: string;
      };
      quantity: {
        requiredError: string;
        integerError: string;
        nonNegativeError: string;
      };
    };
    monitorForm: {
      displayDiagonal: {
        required: string;
        positive: string;
      };
      refreshRate: {
        required: string;
        positive: string;
        int: string;
      };
      latency: {
        required: string;
        positive: string;
        int: string;
      };
      matrix: {
        required: string;
      };
      resolution: {
        width: {
          required: string;
          positive: string;
          int: string;
        };
        height: {
          required: string;
          positive: string;
          int: string;
        };
        type: {
          required: string;
        };
      };
      pixelSize: {
        required: string;
        positive: string;
      };
      brightness: {
        required: string;
        positive: string;
      };
      colorSpectre: {
        required: string;
        positive: string;
      };
    };
    processorForm: {
      cores: {
        requiredError: string;
        integerError: string;
        positiveError: string;
      };
      threads: {
        requiredError: string;
        integerError: string;
        positiveError: string;
      };
      clockSpeed: {
        base: {
          requiredError: string;
          positiveError: string;
        };
        boost: {
          requiredError: string;
          positiveError: string;
        };
      };
      socket: { requiredError: string };
      tdp: {
        requiredError: string;
        positiveError: string;
      };
    };
    motherboardForm: {
      socket: { requiredError: string };
      formFactor: { requiredError: string };
      chipset: { requiredError: string };
      ramSlots: {
        requiredError: string;
        integerError: string;
        positiveError: string;
      };
      pcieSlots: {
        requiredError: string;
        integerError: string;
        positiveError: string;
      };
    };
    graphicsCardForm: {
      memory: {
        capacityInGb: {
          requiredError: string;
          positiveError: string;
        };
        type: {
          minLengthError: string;
        };
        frequency: {
          positiveError: string;
        };
      };
      clockSpeed: {
        base: {
          requiredError: string;
          positiveError: string;
        };
        boost: {
          requiredError: string;
          positiveError: string;
        };
      };
      busWidth: {
        requiredError: string;
        positiveError: string;
      };
      cudaCores: {
        requiredError: string;
        positiveError: string;
      };
      directXSupport: {
        requiredError: string;
        positiveError: string;
      };
      tdp: {
        requiredError: string;
        positiveError: string;
      };
    };
    ramForm: {
      memory: {
        capacityInGb: {
          requiredError: string;
          positiveError: string;
          intError: string;
        };
        type: {
          requiredError: string;
        };
        frequency: {
          requiredError: string;
          positiveError: string;
          intError: string;
        };
      };
      timing: {
        requiredError: string;
      };
    };
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
    createReview: {
      productId: {
        requiredError: string;
        invalidError: string;
      };
      rating: {
        requiredError: string;
      };
      comment: {
        maxLengthError: string;
      };
    };
  };
  components: {
    ramForm: {
      memory: {
        type: string;
        frequency: string;
        capacityInGb: string;
      };
      timing: string;
    };
    ramsDataTable: {
      memory: string;
      timing: string;
    };
    monitorForm: {
      displayDiagonal: string;
      refreshRate: string;
      latency: string;
      matrix: string;
      resolution: {
        width: string;
        height: string;
        type: string;
      };
      pixelSize: string;
      brightness: string;
      colorSpectre: string;
    };
    monitorsDataTable: {
      displayDiagonal: string;
      refreshRate: string;
      latency: string;
      matrix: string;
      resolution: string;
      pixelSize: string;
      brightness: string;
      colorSpectre: string;
    };
    processorsDataTable: {
      cores: string;
      threads: string;
      clockSpeed: string;
      socket: string;
      tdp: string;
    };
    processorForm: {
      cores: string;
      threads: string;
      clockSpeed: {
        base: string;
        boost: string;
      };
      socket: string;
      tdp: string;
    };
    motherboardsDataTable: {
      socket: string;
      formFactor: string;
      chipset: string;
      ramSlots: string;
      pcieSlots: string;
    };
    motherboardForm: {
      socket: string;
      formFactor: string;
      chipset: string;
      ramSlots: string;
      pcieSlots: string;
    };
    graphicsCardsDataTable: {
      memory: string;
      clock: string;
      busWidth: string;
      cudaCores: string;
      directXSupport: string;
      tdp: string;
    };
    graphicsCardForm: {
      memory: {
        type: string;
        frequency: string;
        capacityInGb: string;
      };
      clockSpeed: {
        base: string;
        boost: string;
      };
      chooseAType: string;
      busWidth: string;
      cudaCores: string;
      directXSupport: string;
      tdp: string;
    };
    baseForm: {
      chooseABrand: string;
      add: string;
      addNewProduct: string;
      editingProduct: string;
      fillInDetails: string;
      brand: string;
      modelName: string;
      currentImage: string;
      price: string;
      discountPercentage: string;
      quantity: string;
      cancel: string;
      save: string;
      image: string;
    };
    dataTable: {
      discountPercentage: string;
      price: string;
      quantity: string;
      actions: string;
      confirmDeletion: string;
      areYouSureYouWantToDelete: string;
      cancel: string;
      delete: string;
      sku: string;
      product: string;
      searchBySku: string;
      noResults: string;
      previous: string;
      next: string;
    };
    checkoutForm: {
      pay: string;
      now: string;
    };
    reviewForm: {
      leaveAReview: string;
      shareYourThoughtsAndRatingForThisProduct: string;
      rating: string;
      comment: string;
      leaveAComment: string;
      submitReview: string;
    };
    adminPanelLink: {
      adminPanel: string;
    };
    contactInformationForm: {
      country: string;
      selectCountry: string;
      city: string;
      selectCity: string;
      streetName: string;
      streetNumber: string;
      floor: string;
      apartment: string;
    };
    billingForm: {
      contactInformation: string;
      shippingMethod: string;
      returnPolicyLabel: string;
      returnPolicyText: string;
    };
    emptyCartPage: {
      yourCartIsEmpty: string;
      youHaveNotAddedAnyItemsInYourCart: string;
      GetStartedByAddingAnItem: string;
      AddItems: string;
    };
    chatbot: {
      typeYourMessage: string;
    };
    ordersLink: {
      orders: string;
    };
    cartPage: {
      price: string;
      quantity: string;
      product: string;
      subtotal: string;
      proceedToCheckout: string;
    };
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
      noCommentProvided: string;
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
    productsPagination: {
      previous: string;
      next: string;
      showing: string;
      outOf: string;
      products: string;
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
    useCreateReview: {
      reviewSubmittedSuccessfully: string;
    };
  };
};

export const translation: Translation = {
  validationSchemas: {
    ramForm: {
      memory: {
        capacityInGb: {
          requiredError: 'Capacity is required',
          positiveError: 'Capacity must be positive',
          intError: 'Capacity must be an integer',
        },
        type: {
          requiredError: 'Type is required',
        },
        frequency: {
          requiredError: 'Frequency is required',
          positiveError: 'Frequency must be positive',
          intError: 'Frequency must be an integer',
        },
      },
      timing: {
        requiredError: 'Timing is required',
      },
    },
    monitorForm: {
      displayDiagonal: {
        required: 'Display diagonal is required',
        positive: 'Display diagonal must be positive',
      },
      refreshRate: {
        required: 'Refresh rate is required',
        positive: 'Refresh rate must be positive',
        int: 'Refresh rate must be an integer',
      },
      latency: {
        required: 'Latency is required',
        positive: 'Latency must be positive',
        int: 'Latency must be an integer',
      },
      matrix: {
        required: 'Matrix type is required',
      },
      resolution: {
        width: {
          required: 'Resolution width is required',
          positive: 'Resolution width must be positive',
          int: 'Resolution width must be an integer',
        },
        height: {
          required: 'Resolution height is required',
          positive: 'Resolution height must be positive',
          int: 'Resolution height must be an integer',
        },
        type: {
          required: 'Resolution type is required',
        },
      },
      pixelSize: {
        required: 'Pixel size is required',
        positive: 'Pixel size must be positive',
      },
      brightness: {
        required: 'Brightness is required',
        positive: 'Brightness must be positive',
      },
      colorSpectre: {
        required: 'Color spectre is required',
        positive: 'Color spectre must be positive',
      },
    },
    baseForm: {
      brandId: {
        requiredError: 'Brand is required',
        nonNegativeError: 'Brand ID must be non-negative',
      },
      modelName: {
        requiredError: 'Model name is required',
        minLengthError: 'Model name must be at least 1 character',
      },
      price: {
        requiredError: 'Price is required',
        nonNegativeError: 'Price must be 0 or greater',
      },
      discountPercentage: {
        requiredError: 'Discount is required',
        minError: 'Discount cannot be less than 0%',
        maxError: 'Discount cannot exceed 100%',
      },
      quantity: {
        requiredError: 'Quantity is required',
        integerError: 'Quantity must be an integer',
        nonNegativeError: 'Quantity must be 0 or greater',
      },
    },
    processorForm: {
      cores: {
        requiredError: 'Cores is required',
        integerError: 'Cores must be an integer',
        positiveError: 'Cores must be positive',
      },
      threads: {
        requiredError: 'Threads is required',
        integerError: 'Threads must be an integer',
        positiveError: 'Threads must be positive',
      },
      clockSpeed: {
        base: {
          requiredError: 'Base clock speed is required',
          positiveError: 'Base clock speed must be positive',
        },
        boost: {
          requiredError: 'Boost clock speed is required',
          positiveError: 'Boost clock speed must be positive',
        },
      },
      socket: {
        requiredError: 'Socket is required',
      },
      tdp: {
        requiredError: 'TDP is required',
        positiveError: 'TDP must be positive',
      },
    },
    motherboardForm: {
      socket: { requiredError: 'Socket is required' },
      formFactor: { requiredError: 'Form factor is required' },
      chipset: { requiredError: 'Chipset is required' },
      ramSlots: {
        requiredError: 'RAM slots is required',
        integerError: 'RAM slots must be an integer',
        positiveError: 'RAM slots must be positive',
      },
      pcieSlots: {
        requiredError: 'PCIe slots is required',
        integerError: 'PCIe slots must be an integer',
        positiveError: 'PCIe slots must be positive',
      },
    },
    graphicsCardForm: {
      memory: {
        capacityInGb: {
          requiredError: 'Capacity in GB is required',
          positiveError: 'Capacity in GB must be positive',
        },
        type: {
          minLengthError: 'Type must be at least 1 character',
        },
        frequency: {
          positiveError: 'Frequency must be positive',
        },
      },
      clockSpeed: {
        base: {
          requiredError: 'Base clock speed is required',
          positiveError: 'Base clock speed must be positive',
        },
        boost: {
          requiredError: 'Boost clock speed is required',
          positiveError: 'Boost clock speed must be positive',
        },
      },
      busWidth: {
        requiredError: 'Bus width is required',
        positiveError: 'Bus width must be positive',
      },
      cudaCores: {
        requiredError: 'CUDA cores is required',
        positiveError: 'CUDA cores must be positive',
      },
      directXSupport: {
        requiredError: 'DirectX support is required',
        positiveError: 'DirectX support must be positive',
      },
      tdp: {
        requiredError: 'TDP is required',
        positiveError: 'TDP must be positive',
      },
    },
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
    createReview: {
      productId: {
        requiredError: 'Product ID is required',
        invalidError: 'Invalid product ID',
      },
      rating: {
        requiredError: 'Rating is required',
      },
      comment: {
        maxLengthError: 'Comment cannot exceed 500 characters',
      },
    },
  },
  components: {
    ramForm: {
      memory: {
        type: 'Type',
        frequency: 'Frequency',
        capacityInGb: 'Capacity',
      },
      timing: 'Timing',
    },
    ramsDataTable: {
      memory: 'Memory',
      timing: 'Timing',
    },
    monitorForm: {
      displayDiagonal: 'Display diagonal',
      refreshRate: 'Refresh rate',
      latency: 'Latency',
      matrix: 'Matrix',
      resolution: {
        width: 'Width',
        height: 'Height',
        type: 'Type',
      },
      pixelSize: 'Pixel Size',
      brightness: 'Brightness',
      colorSpectre: 'Color Spectre',
    },
    monitorsDataTable: {
      displayDiagonal: 'Display Diagonal',
      refreshRate: 'Refresh Rate',
      latency: 'Latency',
      matrix: 'Matrix Type',
      resolution: 'Resolution',
      pixelSize: 'Pixel Size',
      brightness: 'Brightness',
      colorSpectre: 'Color Spectre',
    },
    processorForm: {
      cores: 'Cores',
      threads: 'Threads',
      clockSpeed: {
        base: 'Base clock speed (MHz)',
        boost: 'Boost clock speed (MHz)',
      },
      socket: 'Socket',
      tdp: 'TDP (W)',
    },
    processorsDataTable: {
      cores: 'Cores',
      threads: 'Threads',
      clockSpeed: 'Clock Speed',
      socket: 'Socket',
      tdp: 'TDP',
    },
    graphicsCardsDataTable: {
      memory: 'Memory',
      clock: 'Clock',
      busWidth: 'Bus Width',
      cudaCores: 'CUDA Cores',
      directXSupport: 'DirectX',
      tdp: 'TDP',
    },
    baseForm: {
      chooseABrand: 'Choose a brand',
      image: 'Image',
      add: 'Add',
      addNewProduct: 'Add New Product',
      fillInDetails: 'Fill in the details',
      brand: 'Brand',
      modelName: 'Model Name',
      currentImage: 'Current Image',
      price: 'Price (€)',
      discountPercentage: 'Discount (%)',
      quantity: 'Quantity',
      cancel: 'Cancel',
      save: 'Save',
      editingProduct: 'Editing Product',
    },
    dataTable: {
      discountPercentage: 'Discount',
      price: 'Price',
      quantity: 'Quantity',
      actions: 'Actions',
      confirmDeletion: 'Confirm Deletion',
      areYouSureYouWantToDelete: 'Are you sure you want to delete',
      cancel: 'Cancel',
      delete: 'Delete',
      sku: 'SKU',
      product: 'Product',
      searchBySku: 'Search by SKU',
      noResults: 'No results',
      previous: 'Previous',
      next: 'Next',
    },
    checkoutForm: {
      pay: 'Pay',
      now: 'now',
    },
    contactInformationForm: {
      country: 'Country',
      selectCountry: 'Select country',
      city: 'City',
      selectCity: 'Select city',
      streetName: 'Street name',
      streetNumber: 'Street number',
      floor: 'Floor',
      apartment: 'Apartment',
    },
    billingForm: {
      contactInformation: 'Contact Information',
      shippingMethod: 'Shipping Method',
      returnPolicyLabel: 'Return Policy',
      returnPolicyText:
        "We stand behind our products with a comprehensive 30-day return policy. If you're not completely satisfied, simply return the item in its original condition. Our hassle-free return process includes free return shipping and full refunds processed within 48 hours of receiving the returned item.",
    },
    cartPage: {
      price: 'Price',
      quantity: 'Quantity',
      product: 'Product',
      subtotal: 'Subtotal',
      proceedToCheckout: 'Proceed to Checkout',
    },
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
      merchantAddress: import.meta.env.VITE_MERCHANT_ADDRESS,
    },
    searchBox: {
      searchForProducts: 'Search for products...',
    },
    ordersLink: {
      orders: 'Orders',
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
      noCommentProvided: 'No comment provided',
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
    productsPagination: {
      previous: 'Previous',
      next: 'Next',
      showing: 'Showing',
      outOf: 'out of',
      products: 'products',
    },
    emptyCartPage: {
      yourCartIsEmpty: 'Your cart is empty',
      youHaveNotAddedAnyItemsInYourCart:
        'You have not added any items in your cart',
      GetStartedByAddingAnItem: 'Get started by adding an item',
      AddItems: 'Add items',
    },
    adminPanelLink: {
      adminPanel: 'Admin Panel',
    },
    reviewForm: {
      leaveAReview: 'Leave a review',
      shareYourThoughtsAndRatingForThisProduct:
        'Share your thoughts and rating for this product.',
      rating: 'Rating',
      comment: 'Comment',
      leaveAComment: 'Leave a comment...',
      submitReview: 'Submit review',
    },
    graphicsCardForm: {
      memory: {
        type: 'Memory type',
        frequency: 'Frequency',
        capacityInGb: 'Capacity (GB)',
      },
      clockSpeed: {
        base: 'Base clock speed (MHz)',
        boost: 'Boost clock speed (MHz)',
      },
      busWidth: 'Bus width (bits)',
      cudaCores: 'CUDA cores',
      directXSupport: 'DirectX support',
      tdp: 'TDP (W)',
      chooseAType: 'Choose a type',
    },
    motherboardsDataTable: {
      socket: 'Socket',
      formFactor: 'Form factor',
      chipset: 'Chipset',
      ramSlots: 'RAM slots',
      pcieSlots: 'PCIe slots',
    },
    motherboardForm: {
      socket: 'Socket',
      formFactor: 'Form factor',
      chipset: 'Chipset',
      ramSlots: 'RAM slots',
      pcieSlots: 'PCIe slots',
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
    useCreateReview: {
      reviewSubmittedSuccessfully: 'Review submitted successfully.',
    },
  },
};
