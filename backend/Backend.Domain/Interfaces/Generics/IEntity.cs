namespace Backend.Domain.Interfaces.Generics;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}