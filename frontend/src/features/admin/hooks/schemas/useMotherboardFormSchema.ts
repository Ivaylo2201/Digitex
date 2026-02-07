import z from 'zod';
import { useBaseFormSchema } from './useBaseFormSchema';
import { useTranslation } from '@/features/language/hooks/useTranslation';

export function useMotherboardFormSchema() {
  const {
    validationSchemas: { motherboardForm },
  } = useTranslation();
  const baseFormSchema = useBaseFormSchema();

  return baseFormSchema.extend({
    socket: z.string({ required_error: motherboardForm.socket.requiredError }),
    formFactor: z.string({
      required_error: motherboardForm.formFactor.requiredError,
    }),
    chipset: z.string({
      required_error: motherboardForm.chipset.requiredError,
    }),
    ramSlots: z
      .number({ required_error: motherboardForm.ramSlots.requiredError })
      .int(motherboardForm.ramSlots.integerError)
      .positive(motherboardForm.ramSlots.positiveError),
    pcieSlots: z
      .number({ required_error: motherboardForm.pcieSlots.requiredError })
      .int(motherboardForm.pcieSlots.integerError)
      .positive(motherboardForm.pcieSlots.positiveError),
  });
}
