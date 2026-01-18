namespace Backend.Application.Interfaces;

public interface ICurrencyService
{
    IEnumerable<T> ConvertPrices<T>(IEnumerable<T> entities, Action<T> mutate);
    T ConvertPrice<T>(T entity, Action<T> mutate);
}