namespace Backend.Domain.Common;

public delegate IQueryable<TEntity> Query<TEntity>(IQueryable<TEntity> query);