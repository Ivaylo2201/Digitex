import type { ProductLong } from '../models/base/ProductLong';
import type { Monitor } from '../models/Monitor';
import type { GraphicsCard } from '../models/GraphicsCard';
import type { Processor } from '../models/Processor';
import type { Motherboard } from '../models/Motherboard';
import type { Ram } from '../models/Ram';
import type { Ssd } from '../models/Ssd';
import type { PowerSupply } from '../models/PowerSupply';
import { useTranslation } from '@/lib/i18n/hooks/useTranslation';

export function useFormatProduct() {
  const translation = useTranslation();

  const toMonitor = (product: ProductLong) => {
    const monitor = product as Monitor;

    return [
      {
        specificationName: translation.specifications.monitors.displayDiagonal,
        value: `${monitor.displayDiagonal}"`
      },
      {
        specificationName: translation.specifications.monitors.refreshRate,
        value: `${monitor.refreshRate} ${translation.units.hertz}`
      },
      {
        specificationName: translation.specifications.monitors.latency,
        value: `${monitor.latency} ${translation.units.milliseconds}`
      },
      {
        specificationName: translation.specifications.monitors.matrix,
        value: monitor.matrix
      },
      {
        specificationName: translation.specifications.monitors.resolution,
        value: `${monitor.resolution.width}x${monitor.resolution.height} ${monitor.resolution.type}`
      },
      {
        specificationName: translation.specifications.monitors.pixelSize,
        value: `${monitor.pixelSize} ${translation.units.millimeters}`
      },
      {
        specificationName: translation.specifications.monitors.brightness,
        value: `${monitor.brightness} ${translation.units.nits}`
      },
      {
        specificationName: translation.specifications.monitors.colorSpectre,
        value: `${monitor.colorSpectre}%`
      }
    ];
  };

  const toGraphicsCard = (product: ProductLong) => {
    const graphicsCard = product as GraphicsCard;

    return [
      {
        specificationName: translation.specifications.graphicsCards.memory,
        value: `${graphicsCard.memory.capacityInGb}${translation.units.gigabytes} ${graphicsCard.memory.type}`
      },
      {
        specificationName: translation.specifications.processors.baseClockSpeed,
        value: `${graphicsCard.clockSpeed.base.toFixed(2)} ${
          translation.units.megahertz
        }`
      },
      {
        specificationName:
          translation.specifications.processors.boostClockSpeed,
        value: `${graphicsCard.clockSpeed.boost.toFixed(2)} ${
          translation.units.megahertz
        }`
      },
      {
        specificationName: translation.specifications.graphicsCards.busWidth,
        value: `${graphicsCard.busWidth} ${translation.units.bits}`
      },
      {
        specificationName: translation.specifications.graphicsCards.cudaCores,
        value: graphicsCard.cudaCores
      },
      {
        specificationName:
          translation.specifications.graphicsCards.directXSupport,
        value: graphicsCard.directXSupport
      },
      {
        specificationName: translation.specifications.graphicsCards.tdp,
        value: `${graphicsCard.tdp} ${translation.units.watts}`
      }
    ];
  };

  const toProcessor = (product: ProductLong) => {
    const processor = product as Processor;

    return [
      {
        specificationName: translation.specifications.processors.cores,
        value: processor.cores
      },
      {
        specificationName: translation.specifications.processors.threads,
        value: processor.threads
      },
      {
        specificationName: translation.specifications.processors.baseClockSpeed,
        value: `${processor.clockSpeed.base.toFixed(2)} ${
          translation.units.megahertz
        }`
      },
      {
        specificationName:
          translation.specifications.processors.boostClockSpeed,
        value: `${processor.clockSpeed.boost.toFixed(2)} ${
          translation.units.megahertz
        }`
      },
      {
        specificationName: translation.specifications.processors.socket,
        value: processor.socket
      },
      {
        specificationName: translation.specifications.processors.tdp,
        value: `${processor.tdp} ${translation.units.watts}`
      }
    ];
  };

  const toMotherboard = (product: ProductLong) => {
    const motherboard = product as Motherboard;

    return [
      {
        specificationName: translation.specifications.motherboards.socket,
        value: motherboard.socket
      },
      {
        specificationName: translation.specifications.motherboards.formFactor,
        value: motherboard.formFactor
      },
      {
        specificationName: translation.specifications.motherboards.chipset,
        value: motherboard.chipset
      },
      {
        specificationName: translation.specifications.motherboards.ramSlots,
        value: motherboard.ramSlots
      },
      {
        specificationName: translation.specifications.motherboards.pcieSlots,
        value: motherboard.pcieSlots
      }
    ];
  };

  const toRam = (product: ProductLong) => {
    const ram = product as Ram;

    return [
      {
        specificationName: translation.specifications.rams.memory,
        value: `${ram.memory.capacityInGb}${
          translation.units.gigabytes
        } ${ram.memory.type.toUpperCase()}`
      },
      {
        specificationName: translation.specifications.rams.timing,
        value: ram.timing
      }
    ];
  };

  const toSsd = (product: ProductLong) => {
    const ssd = product as Ssd;

    return [
      {
        specificationName: translation.specifications.ssds.capacityInGb,
        value: `${ssd.capacityInGb}${translation.units.gigabytes}`
      },
      {
        specificationName: translation.specifications.ssds.interface,
        value: ssd.interface
      },
      {
        specificationName: translation.specifications.ssds.operationSpeedRead,
        value: `${ssd.operationSpeed.read} ${translation.units.mbPerSecond}`
      },
      {
        specificationName: translation.specifications.ssds.operationSpeedWrite,
        value: `${ssd.operationSpeed.write} ${translation.units.mbPerSecond}`
      }
    ];
  };

  const toPowerSupply = (product: ProductLong) => {
    const powerSupply = product as PowerSupply;

    return [
      {
        specificationName: translation.specifications.powerSupplies.formFactor,
        value: powerSupply.formFactor
      },
      {
        specificationName:
          translation.specifications.powerSupplies.efficiencyPercentage,
        value: `${powerSupply.efficiencyPercentage}%`
      },
      {
        specificationName:
          translation.specifications.powerSupplies.modularity.label,
        value:
          translation.specifications.powerSupplies.modularity[
            powerSupply.modularity.toLowerCase()
          ]
      },
      {
        specificationName: translation.specifications.powerSupplies.wattage,
        value: `${powerSupply.wattage} ${translation.units.watts}`
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
