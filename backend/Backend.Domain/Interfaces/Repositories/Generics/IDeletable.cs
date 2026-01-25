namespace Backend.Domain.Interfaces.Repositories.Generics;

public interface IDeletable<in TKey>
{
    Task DeleteAsync(TKey id, CancellationToken cancellationToken);
}