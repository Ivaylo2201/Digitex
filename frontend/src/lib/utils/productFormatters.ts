import type { Processor } from '@/features/products/models/Processor';
import type { Translation } from '../i18n/models/Translation';
import type { Monitor } from '@/features/products/models/Monitor';
import type { GraphicsCard } from '@/features/products/models/GraphicsCard';

export const formatProcessor = (
  processor: Processor,
  translation: Translation
) => {
  const specs = [
    {
      spec: translation.specs.processors.cores,
      value: processor.cores
    },
    {
      spec: translation.specs.processors.threads,
      value: processor.threads
    },
    {
      spec: translation.specs.processors.baseClockSpeed,
      value: `${processor.clockSpeed.base.toFixed(2)} MHz`
    },
    {
      spec: translation.specs.processors.boostClockSpeed,
      value: `${processor.clockSpeed.boost.toFixed(2)} MHz`
    },
    {
      spec: translation.specs.processors.socket,
      value: processor.socket.toUpperCase()
    },
    {
      spec: translation.specs.processors.tdp,
      value: `${processor.tdp} W`
    }
  ];

  return specs;
};

export const formatMonitor = (monitor: Monitor, translation: Translation) => {
  const specs = [
    {
      spec: translation.specs.monitors.displayDiagonal,
      value: `${monitor.displayDiagonal}"`
    },
    {
      spec: translation.specs.monitors.refreshRate,
      value: `${monitor.refreshRate} Hz`
    },
    {
      spec: translation.specs.monitors.latency,
      value: `${monitor.latency} ms`
    },
    {
      spec: translation.specs.monitors.matrix,
      value: monitor.matrix.toUpperCase()
    },
    {
      spec: translation.specs.monitors.resolution,
      value: `${monitor.resolution.width}x${
        monitor.resolution.height
      } ${monitor.resolution.type.toUpperCase()}`
    },
    {
      spec: translation.specs.monitors.pixelSize,
      value: `${monitor.pixelSize} mm`
    },
    {
      spec: translation.specs.monitors.brightness,
      value: `${monitor.brightness} nits`
    },
    {
      spec: translation.specs.monitors.colorSpectre,
      value: `${monitor.colorSpectre}%`
    }
  ];

  return specs;
};

export const formatGraphicsCard = (
  graphicsCard: GraphicsCard,
  translation: Translation
) => {
  const specs = [
    {
      spec: translation.specs.graphicsCards.memory,
      value: `${graphicsCard.memory.capacityInGb}GB ${graphicsCard.memory.type.toUpperCase()}`
    },
    {
      spec: translation.specs.processors.baseClockSpeed,
      value: `${graphicsCard.clockSpeed.base.toFixed(2)} MHz`
    },
    {
      spec: translation.specs.processors.boostClockSpeed,
      value: `${graphicsCard.clockSpeed.boost.toFixed(2)} MHz`
    },
    {
      spec: translation.specs.graphicsCards.busWidth,
      value: `${graphicsCard.busWidth}-bit`
    },
    {
      spec: translation.specs.graphicsCards.cudaCores,
      value: graphicsCard.cudaCores
    },
    {
      spec: translation.specs.graphicsCards.directXSupport,
      value: graphicsCard.directXSupport
    },
    {
      spec: translation.specs.graphicsCards.tdp,
      value: `${graphicsCard.tdp} W`
    }
  ];

  return specs;
};
