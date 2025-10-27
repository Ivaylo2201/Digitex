namespace Backend.Domain.Common;

public delegate IQueryable<TEntity> Filter<TEntity>(IQueryable<TEntity> query);