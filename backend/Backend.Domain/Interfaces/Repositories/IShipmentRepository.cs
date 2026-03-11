using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface IShipmentRepository : IMultipleReadable<Shipment>, ISingleReadable<Shipment, int>;