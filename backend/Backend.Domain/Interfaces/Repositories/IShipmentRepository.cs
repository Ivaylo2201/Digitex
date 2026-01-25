using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories.Generics;

namespace Backend.Domain.Interfaces;

public interface IShipmentRepository : IMultipleReadable<Shipment>;