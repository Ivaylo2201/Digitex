import z from 'zod';
import { useBaseFormSchema } from './useBaseFormSchema';
import { useTranslation } from '@/features/language/hooks/useTranslation';

export function useProcessorFormSchema() {
  const {
    validationSchemas: { processorForm },
  } = useTranslation();
  const baseFormSchema = useBaseFormSchema();

  return baseFormSchema.extend({
    cores: z
      .number({ required_error: processorForm.cores.requiredError })
      .int(processorForm.cores.integerError)
      .positive(processorForm.cores.positiveError),
    threads: z
      .number({ required_error: processorForm.threads.requiredError })
      .int(processorForm.threads.integerError)
      .positive(processorForm.threads.positiveError),
    clockSpeed: z.object({
      base: z
        .number({
          required_error: processorForm.clockSpeed.base.requiredError,
        })
        .positive(processorForm.clockSpeed.base.positiveError),
      boost: z
        .number({
          required_error: processorForm.clockSpeed.boost.requiredError,
        })
        .positive(processorForm.clockSpeed.boost.positiveError),
    }),
    socket: z.string({ required_error: processorForm.socket.requiredError }),
    tdp: z
      .number({ required_error: processorForm.tdp.requiredError })
      .positive(processorForm.tdp.positiveError),
  });
}
