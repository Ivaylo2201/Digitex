import type { Translation } from '@/lib/i18n/models/Translation';
import type { ProductLong } from '../models/base/ProductLong';
import type { Monitor } from '../models/Monitor';
import type { GraphicsCard } from '../models/GraphicsCard';
import type { Processor } from '../models/Processor';
import type { Motherboard } from '../models/Motherboard';
import type { Ram } from '../models/Ram';
import type { Ssd } from '../models/Ssd';
import type { PowerSupply } from '../models/PowerSupply';

export function useFormatProduct(translation: Translation) {
  const toMonitor = (product: ProductLong) => {
    const monitor = product as Monitor;

    return [
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
  };

  const toGraphicsCard = (product: ProductLong) => {
    const graphicsCard = product as GraphicsCard;

    return [
      {
        spec: translation.specs.graphicsCards.memory,
        value: `${
          graphicsCard.memory.capacityInGb
        }GB ${graphicsCard.memory.type.toUpperCase()}`
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
  };

  const toProcessor = (product: ProductLong) => {
    const processor = product as Processor;

    return [
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
  };

  const toMotherboard = (product: ProductLong) => {
    const motherboard = product as Motherboard;

    return [
      {
        spec: translation.specs.motherboards.socket,
        value: motherboard.socket.toUpperCase()
      },
      {
        spec: translation.specs.motherboards.formFactor,
        value: motherboard.formFactor
      },
      {
        spec: translation.specs.motherboards.chipset,
        value: motherboard.chipset
      },
      {
        spec: translation.specs.motherboards.ramSlots,
        value: motherboard.ramSlots
      },
      {
        spec: translation.specs.motherboards.pcieSlots,
        value: motherboard.pcieSlots
      }
    ];
  };

  const toRam = (product: ProductLong) => {
    const ram = product as Ram;

    return [
      {
        spec: translation.specs.rams.memory,
        value: `${ram.memory.capacityInGb}GB ${ram.memory.type.toUpperCase()}`
      },
      {
        spec: translation.specs.rams.timing,
        value: ram.timing
      }
    ];
  };

  const toSsd = (product: ProductLong) => {
    const ssd = product as Ssd;

    return [
      {
        spec: translation.specs.ssds.capacityInGb,
        value: `${ssd.capacityInGb}GB`
      },
      {
        spec: translation.specs.ssds.interface,
        value: ssd.interface.toUpperCase()
      },
      {
        spec: translation.specs.ssds.operationSpeedRead,
        value: `${ssd.operationSpeed.read} MB/s`
      },
      {
        spec: translation.specs.ssds.operationSpeedWrite,
        value: `${ssd.operationSpeed.write} MB/s`
      }
    ];
  };

  const toPowerSupply = (product: ProductLong) => {
    const powerSupply = product as PowerSupply;

    return [
      {
        spec: translation.specs.powerSupplies.formFactor,
        value: powerSupply.formFactor.toUpperCase()
      },
      {
        spec: translation.specs.powerSupplies.efficiencyPercentage,
        value: `${powerSupply.efficiencyPercentage}%`
      },
      {
        spec: translation.specs.powerSupplies.modularity['spec'],
        value:
          translation.specs.powerSupplies.modularity[
            powerSupply.modularity.toLowerCase()
          ]
      },
      {
        spec: translation.specs.powerSupplies.wattage,
        value: `${powerSupply.wattage} W`
      }
    ];
  };

  return {
    toMonitor,
    toGraphicsCard,
    toProcessor,
    toMotherboard,
    toRam,
    toSsd,
    toPowerSupply
  };
}
