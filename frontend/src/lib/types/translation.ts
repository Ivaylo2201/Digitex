export type Translation = {
  specs: {
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
      clockSpeed: string;
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
      modularity: string;
    };
    rams: {
      memory: string;
      timing: string;
    };
    ssds: {
      capacityInGb: string;
      operationSpeed: string;
      interface: string;
    };
  };
  routing: {
    monitors: string;
    processors: string;
    graphicsCards: string;
    motherboards: string;
    powerSupplies: string;
    rams: string;
    ssds: string;
  };
  units: {
    hz: string;
    ms: string;
    mm: string;
    nits: string;
    gb: string;
    w: string;
  };
  auth: {
    signIn: string;
    signOut: string;
    verify: string;
  };
  user: {
    cart: string;
    account: string;
    wishlist: string;
  };
  keywords: {
    productSearch: string;
    address: string;
    mainSpecifications: string;
  };
};

export const initialTranslation: Translation = {
  units: {
    gb: 'Gigabytes',
    hz: 'Hz',
    ms: 'ms',
    mm: 'mm',
    nits: 'nits',
    w: 'W'
  },
  specs: {
    monitors: {
      displayDiagonal: 'Display diagonal',
      refreshRate: 'Refresh rate',
      latency: 'Latency',
      matrix: 'Matrix',
      resolution: 'Resolution',
      pixelSize: 'Pixel size',
      brightness: 'Brightness',
      colorSpectre: 'Color spectre'
    },
    processors: {
      cores: 'Cores',
      threads: 'Threads',
      baseClockSpeed: 'Base clock speed',
      boostClockSpeed: 'Boost clock speed',
      socket: 'Socket',
      tdp: 'TDP'
    },
    graphicsCards: {
      memory: 'Memory',
      clockSpeed: 'Clock speed',
      busWidth: 'Bus width',
      cudaCores: 'CUDA cores',
      directXSupport: 'DirectX support',
      tdp: 'TDP'
    },
    motherboards: {
      socket: 'Socket',
      formFactor: 'Form factor',
      chipset: 'Chipset',
      ramSlots: 'RAM slots',
      pcieSlots: 'PCIe slots'
    },
    powerSupplies: {
      wattage: 'Wattage',
      formFactor: 'Form factor',
      efficiencyPercentage: 'Efficiency percentage',
      modularity: 'Modularity'
    },
    rams: {
      memory: 'Memory',
      timing: 'Timing'
    },
    ssds: {
      capacityInGb: 'Capacity (GB)',
      operationSpeed: 'Operation speed',
      interface: 'Interface'
    }
  },
  routing: {
    monitors: 'Monitors',
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
    verify: 'Verify'
  },
  user: {
    cart: 'Cart',
    account: 'Account',
    wishlist: 'Wishlist'
  },
  keywords: {
    productSearch: 'Search for products...',
    address: 'Sofia, Vitosha Blvd. 76',
    mainSpecifications: 'Main specifications'
  }
};
