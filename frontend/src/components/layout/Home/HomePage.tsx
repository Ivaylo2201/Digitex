import { Page } from '../Page';
import { Hero } from './components/Hero';
import { CategoriesSection } from './components/CategoriesSection';
import { ValueProps } from './components/ValueProps';
import { CtaBand } from './components/CtaBand';

export function HomePage() {
  return (
    <Page bleed>
      <Hero />
      <CategoriesSection />
      <ValueProps />
      <CtaBand />
    </Page>
  );
}
