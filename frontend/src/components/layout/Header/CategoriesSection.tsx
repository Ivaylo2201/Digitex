import CategoryLink from '@/components/links/CategoryLink';
import { useTranslation } from '@/lib/stores/useTranslation';
import React from 'react';

export default function CategoriesSection() {
  const translation = useTranslation();

  const categories = [
    { label: translation.processors, route: 'processors' },
    { label: translation.graphicCards, route: 'graphic-cards' },
    { label: translation.powerSupplies, route: 'power-supplies' },
    { label: translation.rams, route: 'rams' },
    { label: translation.ssds, route: 'ssds' },
    { label: translation.motherboards, route: 'motherboards' },
    { label: translation.monitors, route: 'monitors' }
  ];

  return (
    <React.Fragment>
      {categories.map(({ label, route }, idx) => (
        <CategoryLink key={idx} category={label} to={route} />
      ))}
    </React.Fragment>
  );
}
