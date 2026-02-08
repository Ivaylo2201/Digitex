import { useTranslation } from '@/features/language/hooks/useTranslation';
import { useBaseFormSchema } from './useBaseFormSchema';
import z from 'zod';

export function useMonitorFormSchema() {
  const {
    validationSchemas: { monitorForm },
  } = useTranslation();
  const baseFormSchema = useBaseFormSchema();

  return baseFormSchema.extend({
    displayDiagonal: z
      .number({ required_error: monitorForm.displayDiagonal.required })
      .positive(monitorForm.displayDiagonal.positive),

    refreshRate: z
      .number({ required_error: monitorForm.refreshRate.required })
      .positive(monitorForm.refreshRate.positive)
      .int(monitorForm.refreshRate.int),

    latency: z
      .number({ required_error: monitorForm.latency.required })
      .positive(monitorForm.latency.positive),

    matrix: z.string({ required_error: monitorForm.matrix.required }),

    resolution: z.object({
      width: z
        .number({ required_error: monitorForm.resolution.width.required })
        .positive(monitorForm.resolution.width.positive)
        .int(monitorForm.resolution.width.int),
      height: z
        .number({ required_error: monitorForm.resolution.height.required })
        .positive(monitorForm.resolution.height.positive)
        .int(monitorForm.resolution.height.int),
      type: z.string({ required_error: monitorForm.resolution.type.required }),
    }),

    pixelSize: z
      .number({ required_error: monitorForm.pixelSize.required })
      .positive(monitorForm.pixelSize.positive),

    brightness: z
      .number({ required_error: monitorForm.brightness.required })
      .positive(monitorForm.brightness.positive),

    colorSpectre: z
      .number({ required_error: monitorForm.colorSpectre.required })
      .positive(monitorForm.colorSpectre.positive),
  });
}
