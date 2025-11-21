import { create } from 'zustand';
import type { Translation } from '@/lib/i18n/models/Translation';
import type { ProductLong } from '@/features/products/models/base/ProductLong';

type CompareActionResult = { isSuccess: boolean; message: string };

type CompareStore = {
  category: string | null;
  products: ProductLong[];
  addToCompare: (product: ProductLong & { category: string }, translation: Translation) => CompareActionResult;
  removeFromCompare: (id: string, translation: Translation) => CompareActionResult;
  isAddedToCompare: (id: string) => boolean;
  clearCompare: () => void;
};

export const useCompare = create<CompareStore>((set, get) => ({
  category: null,
  products: [],
  addToCompare: (comparedProduct, translation) => {
    const category = get().category;
    const products = get().products;

    if (products.length >= 10)
      return {
        isSuccess: false,
        message: translation.compare.maxCapacityReached
      };

    if (category && comparedProduct.category !== category)
      return {
        isSuccess: false,
        message: translation.compare.incompatibleCategory
      };

    const { category: _, ...rest } = comparedProduct;
    set({ products: [...products, rest], category: comparedProduct.category });

    return { isSuccess: true, message: translation.compare.addedSuccessfully };
  },
  removeFromCompare: (id, translation) => {
    const filteredProducts = get().products.filter(
      (product) => product.id !== id
    );

    set({ products: filteredProducts });

    if (filteredProducts.length === 0) {
      set({ category: null });
    }

    return {
      isSuccess: true,
      message: translation.compare.removedSuccessfully
    };
  },
  isAddedToCompare: (id) => {
    return get().products.some((product) => product.id === id);
  },
  clearCompare: () => {
    set({ products: [], category: null });
  }
}));
