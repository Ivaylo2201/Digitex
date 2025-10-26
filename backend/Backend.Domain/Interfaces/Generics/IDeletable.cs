namespace Backend.Domain.Interfaces.Generics;

public interface IDeletable<in TKey>
{
    Task DeleteAsync(TKey id, CancellationToken ct = default);
}