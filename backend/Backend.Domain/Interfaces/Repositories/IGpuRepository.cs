using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories.Generic;

namespace Backend.Domain.Interfaces.Repositories;

public interface IGpuRepository : 
    ISingleReadable<Gpu, Guid>,
    IMultipleReadable<Gpu>;