import type { BaseFormData } from './BaseFormData';

export type ProcessorFormData = BaseFormData & {
  cores: number;
  threads: number;
  clockSpeed: {
    base: number;
    boost: number;
  };
  socket: string;
  tdp: number;
};
