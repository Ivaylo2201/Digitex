using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;
using Backend.Domain.Interfaces.Repositories.Generics;

namespace Backend.Domain.Interfaces;

public interface ICountryRepository : IMultipleReadable<Country>;