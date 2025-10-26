namespace Backend.Domain.Common;

public delegate IQueryable<TEntity> FilterQuery<TEntity>(IQueryable<TEntity> query);