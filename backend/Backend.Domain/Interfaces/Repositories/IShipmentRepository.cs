using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IShipmentRepository : IMultipleReadable<Shipment>;