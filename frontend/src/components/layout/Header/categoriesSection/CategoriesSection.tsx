import CategoryLink from "@/components/layout/header/categoriesSection/CategoryLink";
import { useTranslation } from "@/lib/stores/useTranslation";
import React from "react";

export default function CategoriesSection() {
  const translation = useTranslation();

  const categories = [
    {
      categoryName: translation.products.processors,
      route: "/processors",
    },
    {
      categoryName: translation.products.graphicsCards,
      route: "/graphics-cards",
    },
    {
      categoryName: translation.products.motherboards,
      route: "/motherboards",
    },
    {
      categoryName: translation.products.rams,
      route: "/rams",
    },
    {
      categoryName: translation.products.ssds,
      route: "/ssds",
    },
    {
      categoryName: translation.products.powerSupplies,
      route: "/power-supplies",
    },
    {
      categoryName: translation.products.monitors,
      route: "/monitors",
    },
  ];

  return (
    <React.Fragment>
      {categories.map((category, idx) => (
        <CategoryLink key={idx} {...category} />
      ))}
    </React.Fragment>
  );
}
