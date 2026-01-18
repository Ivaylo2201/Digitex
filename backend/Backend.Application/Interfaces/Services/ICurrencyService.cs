namespace Backend.Application.Interfaces.Services;

public interface ICurrencyService
{
    IEnumerable<T> ConvertPrices<T>(IEnumerable<T> entities, Action<T> mutate);
    T ConvertPrice<T>(T entity, Action<T> mutate);
}