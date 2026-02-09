import { useTranslation } from '@/features/language/hooks/useTranslation';
import { useBaseFormSchema } from './useBaseFormSchema';
import z from 'zod';

export function useSsdFormSchema() {
  const {
    validationSchemas: { ssdForm },
  } = useTranslation();
  const baseFormSchema = useBaseFormSchema();

  return baseFormSchema.extend({
    capacityInGb: z
      .number({ required_error: ssdForm.capacityInGb.requiredError })
      .int(ssdForm.capacityInGb.intError)
      .positive(ssdForm.capacityInGb.positiveError),
    readOperationSpeed: z
      .number({ required_error: ssdForm.operationSpeed.read.requiredError })
      .int(ssdForm.operationSpeed.read.intError)
      .positive(ssdForm.operationSpeed.read.positiveError),
    writeOperationSpeed: z
      .number({ required_error: ssdForm.operationSpeed.write.requiredError })
      .int(ssdForm.operationSpeed.write.intError)
      .positive(ssdForm.operationSpeed.write.positiveError),
    storageInterface: z.string({
      required_error: ssdForm.storageInterface.requiredError,
    }),
  });
}
