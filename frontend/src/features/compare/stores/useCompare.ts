import { create } from 'zustand';
import type { Translation } from '@/features/language/models/Translation';
import type { ProductLong } from '@/features/products/models/base/ProductLong';

type CompareStore = {
  category: string | null;
  products: ProductLong[];
  addToCompare: (
    product: ProductLong & { category: string },
    addToCompareTranslation: Translation['components']['addToCompareButton']
  ) => { isSuccess: boolean; message: string };
  removeFromCompare: (id: string) => void;
  clearCompare: () => void;
};

export const useCompare = create<CompareStore>((set, get) => ({
  category: null,
  products: [],
  addToCompare: (comparedProduct, addToCompareTranslation) => {
    const category = get().category;
    const products = get().products;

    if (products.length >= 10)
      return {
        isSuccess: false,
        message: addToCompareTranslation.maxComparisonCapacityReached
      };

    if (category && comparedProduct.category !== category)
      return {
        isSuccess: false,
        message: addToCompareTranslation.incompatibleComparisonCategory
      };

    if (products.some((product) => product.id === comparedProduct.id))
      return {
        isSuccess: false,
        message: addToCompareTranslation.productAlreadyAddedToComparison
      };

    const { category: _, ...rest } = comparedProduct;
    set({ products: [...products, rest], category: comparedProduct.category });

    return {
      isSuccess: true,
      message: addToCompareTranslation.productSuccessfullyAddedToComparison
    };
  },
  removeFromCompare: (id) => {
    const filteredProducts = get().products.filter(
      (product) => product.id !== id
    );

    set({ products: filteredProducts });

    if (filteredProducts.length === 0) {
      set({ category: null });
    }
  },
  clearCompare: () => {
    set({ products: [], category: null });
  }
}));
