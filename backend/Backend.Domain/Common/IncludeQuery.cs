namespace Backend.Domain.Common;

public delegate IQueryable<TEntity> IncludeQuery<TEntity>(IQueryable<TEntity> query);