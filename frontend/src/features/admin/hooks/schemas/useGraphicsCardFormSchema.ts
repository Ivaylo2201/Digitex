import z from 'zod';
import { useBaseFormSchema } from './useBaseFormSchema';
import { useTranslation } from '@/features/language/hooks/useTranslation';

export function useGraphicsCardFormSchema() {
  const {
    validationSchemas: { graphicsCardForm },
  } = useTranslation();
  const baseFormSchema = useBaseFormSchema();

  return baseFormSchema.extend({
    memory: z.object({
      capacityInGb: z
        .number({
          required_error: graphicsCardForm.memory.capacityInGb.requiredError,
        })
        .positive(graphicsCardForm.memory.capacityInGb.positiveError),
      type: z.string().min(1, graphicsCardForm.memory.type.minLengthError),
      frequency: z
        .number()
        .positive(graphicsCardForm.memory.frequency.positiveError),
    }),
    clockSpeed: z.object({
      base: z
        .number({
          required_error: graphicsCardForm.clockSpeed.base.requiredError,
        })
        .positive(graphicsCardForm.clockSpeed.base.positiveError),
      boost: z
        .number({
          required_error: graphicsCardForm.clockSpeed.boost.requiredError,
        })
        .positive(graphicsCardForm.clockSpeed.boost.positiveError),
    }),
    busWidth: z
      .number({ required_error: graphicsCardForm.busWidth.requiredError })
      .positive(graphicsCardForm.busWidth.positiveError),
    cudaCores: z
      .number({ required_error: graphicsCardForm.cudaCores.requiredError })
      .int()
      .positive(graphicsCardForm.cudaCores.positiveError),
    directXSupport: z
      .number({ required_error: graphicsCardForm.directXSupport.requiredError })
      .positive(graphicsCardForm.directXSupport.positiveError),
    tdp: z
      .number({ required_error: graphicsCardForm.tdp.requiredError })
      .positive(graphicsCardForm.tdp.positiveError),
  });
}
