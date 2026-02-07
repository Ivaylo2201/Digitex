import type { BaseFormData } from './BaseFormData';

export type MotherboardFormData = BaseFormData & {
  socket: string;
  formFactor: string;
  chipset: string;
  ramSlots: number;
  pcieSlots: number;
};
