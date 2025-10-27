using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Infrastructure.Services.Base;

public class GetEntityServiceBase<TEntity, TKey, TProjection>(ISingleReadable<TEntity, TKey> repository)
{
    public async Task<Result<TProjection?>> GetOneAsync(TKey id, Func<TEntity, TProjection> project, CancellationToken ct)
    {
        var entity = await repository.GetOneAsync(id, ct);
        
        if (entity is null)
            return Result<TProjection?>.Failure(ErrorType.NotFound);       
        
        return Result<TProjection?>.Success(project(entity));   
    }
}