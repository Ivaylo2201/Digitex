import { useTranslation } from '@/features/language/hooks/useTranslation';
import { useBaseFormSchema } from './useBaseFormSchema';
import z from 'zod';

export function usePowerSupplyFormSchema() {
  const {
    validationSchemas: { powerSupplyForm },
  } = useTranslation();
  const baseFormSchema = useBaseFormSchema();

  return baseFormSchema.extend({
    wattage: z
      .number({ required_error: powerSupplyForm.wattage.requiredError })
      .int({ message: powerSupplyForm.wattage.intError })
      .positive({ message: powerSupplyForm.wattage.positiveError }),
    efficiencyPercentage: z
      .number({
        required_error: powerSupplyForm.efficiencyPercentage.requiredError,
      })
      .int({ message: powerSupplyForm.efficiencyPercentage.intError })
      .positive({
        message: powerSupplyForm.efficiencyPercentage.positiveError,
      }),
  });
}
