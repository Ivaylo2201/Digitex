using Backend.Application.CQRS.Generic.Queries;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.CQRS.Motherboard.Queries;

using Motherboard = Domain.Entities.Motherboard;

public class ListMotherboardsQuery : ListEntitiesQuery<Motherboard>
{
    public override Func<IQueryable<Motherboard>, IQueryable<Motherboard>> Include 
        => query => query.Include(cpu => cpu.Brand);
}