import CategoryLink from '@/components/layout/header/categoriesSection/CategoryLink';
import { useTranslation } from '@/lib/stores/useTranslation';
import React from 'react';

export default function CategoriesSection() {
  const translation = useTranslation();

  const categories = [
    { name: translation.products.processors, route: 'processors' },
    { name: translation.products.graphicsCards, route: 'graphics-cards' },
    { name: translation.products.motherboards, route: 'motherboards' },
    { name: translation.products.rams, route: 'rams' },
    { name: translation.products.ssds, route: 'ssds' },
    { name: translation.products.powerSupplies, route: 'power-supplies' },
    { name: translation.products.monitors, route: 'monitors' }
  ];

  return (
    <React.Fragment>
      {categories.map((category, idx) => (
        <CategoryLink key={idx} category={category.name} to={category.route} />
      ))}
    </React.Fragment>
  );
}
