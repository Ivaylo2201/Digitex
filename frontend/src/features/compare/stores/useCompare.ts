import { create } from 'zustand';
import type { Translation } from '@/lib/i18n/models/Translation';
import type { ProductLong } from '@/features/products/models/base/ProductLong';

type CompareActionResult = { isSuccess: boolean; message: string };

type CompareStore = {
  category: string | null;
  products: ProductLong[];
  addToCompare: (
    product: ProductLong & { category: string },
    translation: Translation
  ) => CompareActionResult;
  removeFromCompare: (id: string) => void;
  clearCompare: () => void;
};

export const useCompare = create<CompareStore>((set, get) => ({
  category: null,
  products: [],
  addToCompare: (product, translation) => {
    const category = get().category;
    const products = get().products;

    if (products.length >= 10)
      return {
        isSuccess: false,
        message: translation.compare.maxCapacityReached
      };

    if (category && product.category !== category)
      return {
        isSuccess: false,
        message: translation.compare.incompatibleCategory
      };

    if (products.some((p) => p.id === product.id))
      return {
        isSuccess: false,
        message: translation.compare.alreadyPresent
      };

    const { category: _, ...rest } = product;
    set({ products: [...products, rest], category: product.category });

    return { isSuccess: true, message: translation.compare.addedSuccessfully };
  },
  removeFromCompare: (id) => {
    const products = get().products;
    set({ products: products.filter((p) => p.id !== id) });

    if (products.length <= 0) {
      set({ category: null });
    }
  },
  clearCompare: () => {
    set({ products: [], category: null });
  }
}));
