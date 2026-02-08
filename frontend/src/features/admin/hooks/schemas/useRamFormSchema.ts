import { useTranslation } from '@/features/language/hooks/useTranslation';
import { useBaseFormSchema } from './useBaseFormSchema';
import z from 'zod';

export function useRamFormSchema() {
  const {
    validationSchemas: { ramForm },
  } = useTranslation();
  const baseFormSchema = useBaseFormSchema();

  return baseFormSchema.extend({
    memory: z.object({
      capacityInGb: z
        .number({
          required_error: ramForm.memory.capacityInGb.requiredError,
        })
        .positive(ramForm.memory.capacityInGb.positiveError),
      type: z.string({ required_error: ramForm.memory.type.requiredError }),
      frequency: z.number().positive(ramForm.memory.frequency.positiveError),
    }),
    timing: z.string({ required_error: ramForm.timing.requiredError }),
  });
}
