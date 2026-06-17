import {
  Cpu,
  Gpu,
  CircuitBoard,
  MemoryStick,
  HardDrive,
  Plug,
  Monitor,
  type LucideIcon,
} from 'lucide-react';
import type { Translation } from '@/features/language/models/Translation';

export type HomeCategory = {
  slug: string;
  icon: LucideIcon;
  routeKey: keyof Translation['routeNames'];
};

/**
 * The seven product categories surfaced on the home page. Slugs map directly
 * to the `/products/categories/:category` route; labels are pulled from the
 * shared `routeNames` translations so the grid stays in sync with the navbar.
 */
export const homeCategories: HomeCategory[] = [
  { slug: 'processors', icon: Cpu, routeKey: 'processors' },
  { slug: 'graphics-cards', icon: Gpu, routeKey: 'graphics-cards' },
  { slug: 'motherboards', icon: CircuitBoard, routeKey: 'motherboards' },
  { slug: 'rams', icon: MemoryStick, routeKey: 'rams' },
  { slug: 'ssds', icon: HardDrive, routeKey: 'ssds' },
  { slug: 'power-supplies', icon: Plug, routeKey: 'power-supplies' },
  { slug: 'monitors', icon: Monitor, routeKey: 'monitors' },
];
