import CategoryLink from '@/components/links/CategoryLink';
import { useTranslation } from '@/lib/stores/useTranslation';
import React from 'react';

export default function CategoriesSection() {
  const translation = useTranslation();

  const categories = [
    { name: translation.processors, route: 'processors' },
    { name: translation.graphicCards, route: 'graphic-cards' },
    { name: translation.motherboards, route: 'motherboards' },
    { name: translation.rams, route: 'rams' },
    { name: translation.ssds, route: 'ssds' },
    { name: translation.powerSupplies, route: 'power-supplies' },
    { name: translation.monitors, route: 'monitors' }
  ];

  return (
    <React.Fragment>
      {categories.map((category, idx) => (
        <CategoryLink key={idx} category={category.name} to={category.route} />
      ))}
    </React.Fragment>
  );
}
